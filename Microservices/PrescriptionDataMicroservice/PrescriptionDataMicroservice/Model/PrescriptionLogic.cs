namespace PrescriptionDataMicroservice
{
    public class PrescriptionLogic : IPrescription
    {
        private static readonly List<Prescription> Prescriptions;

        private static readonly object prescriptionLock = new object();

        private const string prescriptionsFilename = "JsonStorage/prescriptions.json";

        static PrescriptionLogic()
        {
            PrescriptionReader prescriptionReader = new PrescriptionReader();

            lock (prescriptionLock)
            {
                List<Prescription> prescriptions = prescriptionReader.ReadPrescriptions(prescriptionsFilename);
                Prescriptions = prescriptions;
            }
        }

        public PrescriptionLogic()
        {
        }

        public List<Prescription> GetPrescriptions()
        {
            lock (prescriptionLock)
            {
                return Prescriptions;
            }
        }

        public void AddPrescription(Prescription prescription)
        {
            prescription.Id = Guid.NewGuid().ToString();
            lock (prescriptionLock)
            {
                Prescriptions.Add(prescription);
                SavePrescriptionToJsonFile(prescriptionsFilename);
            }
        }

        public void SavePrescriptionToJsonFile(string filename)
        {
            lock (prescriptionLock)
            {
                PrescriptionWriter prescriptionWriter = new PrescriptionWriter();
                prescriptionWriter.WritePrescriptionsToJsonFile(Prescriptions, filename);
            }
        }

        public Prescription GetPrescriptionById(string Id)
        {
            lock (prescriptionLock)
            {
                foreach (Prescription prescription in Prescriptions)
                {
                    if (prescription.Id == Id)
                    {
                        return prescription;
                    }
                }
            }
            return null;
        }

        public List<Prescription> GetPrescriptionByDoctorID(string doctorId)
        {
            lock (prescriptionLock)
            {
                return Prescriptions.Where(prescription => prescription.DoctorId.Equals(doctorId)).ToList();
            }
            return null;
        }

        public List<Prescription> GetPrescriptionByPatientID(string patientId)
        {
            lock (prescriptionLock)
            {
                return Prescriptions.Where(prescription => prescription.PatientId.Equals(patientId)).ToList();
            }
            return null;
        }
        public void RemovePrescription(string Id)
        {
            lock (prescriptionLock)
            {
                Prescriptions.RemoveAll(x => x.Id == Id);
                SavePrescriptionToJsonFile(prescriptionsFilename);
            }

        }
    }
}
