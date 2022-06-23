using Newtonsoft.Json;

namespace PatientApplicationMicroservice
{
    public class PrescriptionApplicationHandler : IPrescriptionApplicationHandler
    {
        private readonly IPrescriptionDataServiceClient prescriptionDataServiceClient;
        private readonly IDoctorDataServiceClient doctorDataServiceClient;
        private readonly IPatientDataServiceClient patientDataServiceClient;
        private readonly IDrugDataServiceClient drugDataServiceClient;

        public PrescriptionApplicationHandler(IPrescriptionDataServiceClient prescriptionDataServiceClient, IDoctorDataServiceClient doctorDataServiceClient, 
            IPatientDataServiceClient patientDataServiceClient, IDrugDataServiceClient drugDataServiceClient)
        {
            this.prescriptionDataServiceClient = prescriptionDataServiceClient;
            this.doctorDataServiceClient = doctorDataServiceClient;
            this.patientDataServiceClient = patientDataServiceClient;
            this.drugDataServiceClient = drugDataServiceClient;
        }
        public async Task<IEnumerable<PrescriptionDataFull>> GetAllFullPrescriptions()
        {
            List<PrescriptionDataFull> prescriptions = new List<PrescriptionDataFull>();
            IEnumerable<PrescriptionData> prescriptionDatas = prescriptionDataServiceClient.GetAllPrescriptions().Result;
            foreach (PrescriptionData prescriptionData in prescriptionDatas)
            {
                prescriptions.Add(ProcessPrescriptionDataToPrescriptionDataFull(prescriptionData));
            }
            return prescriptions;
        }
        public async Task<IEnumerable<PrescriptionData>> GetAllPrescriptions()
        {
            IEnumerable<PrescriptionData> prescriptionDatas = prescriptionDataServiceClient.GetAllPrescriptions().Result;
            return prescriptionDatas;
        }

        public async Task<PrescriptionDataFull> GetPrescriptionById(string id)
        {
            PrescriptionData prescriptionData = prescriptionDataServiceClient.GetPrescriptionById(id).Result;
            return ProcessPrescriptionDataToPrescriptionDataFull(prescriptionData);
        }

        public async void AddPrescription(PrescriptionData prescriptionData)
        {
            prescriptionDataServiceClient.AddPrescription(prescriptionData);
        }

        private PrescriptionDataFull ProcessPrescriptionDataToPrescriptionDataFull(PrescriptionData prescriptionData)
        {
            DoctorData doctor = doctorDataServiceClient.GetDoctorById(prescriptionData.DoctorId).Result;
            PatientData patient = patientDataServiceClient.GetPatientById(prescriptionData.PatientId).Result;
            Dictionary<string, string> prescriptionContent = prescriptionData.Content;
            Dictionary<string, string> prescriptinoContentFull = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> kvp in prescriptionContent)
            {
                string newKey = drugDataServiceClient.GetDrugById(kvp.Key).Result.Name;
                prescriptinoContentFull.Add(newKey, kvp.Value);
            }
            PrescriptionDataFull prescriptionDataFull = new PrescriptionDataFull(prescriptionData.Id, prescriptionData.DateCreated, prescriptionData.DateValidThrough,
                doctor, patient, prescriptinoContentFull);
            return prescriptionDataFull;
        }

        public async Task<IEnumerable<PrescriptionDataFull>> GetPrescriptionsByPatientPesel(string pesel)
        {
            string patientId = patientDataServiceClient.GetPatientByPesel(pesel).Result.Id;
            List<PrescriptionDataFull> prescriptions = new List<PrescriptionDataFull>();
            List<PrescriptionData> prescriptionDatas =  prescriptionDataServiceClient.GetPrescriptionsByPatientId(patientId).Result.ToList();
            foreach (PrescriptionData prescriptionData in prescriptionDatas)
            {
                prescriptions.Add(ProcessPrescriptionDataToPrescriptionDataFull(prescriptionData));
            }
            return prescriptions;
        }

        public async void OrderPrescription(string id)
        {
            prescriptionDataServiceClient.OrderPrescription(id);
        }
    }
}
