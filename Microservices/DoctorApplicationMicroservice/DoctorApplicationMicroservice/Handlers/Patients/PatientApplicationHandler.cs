namespace DoctorApplicationMicroservice
{
    public class PatientApplicationHandler : IPatientApplicationHandler
    {
        private readonly IPatientDataServiceClient PatientDataServiceClient;

        public PatientApplicationHandler(IPatientDataServiceClient doctorDataServiceClient)
        {
            this.PatientDataServiceClient = doctorDataServiceClient;
        }
        public async Task<IEnumerable<PatientData>> GetAllPatients()
        {
            return await PatientDataServiceClient.GetAllPatients();
        }

        public async Task<PatientData> GetPatientById(string id)
        {
            return await PatientDataServiceClient.GetPatientById(id);
        }

        public async Task<PatientData> GetPatientByPesel(string pesel)
        {
            return await PatientDataServiceClient.GetPatientByPesel(pesel);
        }
        public async void AddPatient(PatientData patientData)
        {
            PatientDataServiceClient.AddPatient(patientData);
        }
        public async void RemovePatient(string id)
        {
            PatientDataServiceClient.RemovePatient(id);
        }
    }
}
