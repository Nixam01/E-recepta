namespace PatientDataMicroservice
{
    public class PatientLogic : IPatient
    {
        private static List<Patient> Patients;

        private static readonly object patientLock = new object();

        private const string patientsFilename = "JsonStorage/patients.json";

        static PatientLogic()
        {
            PatientReader patientReader = new PatientReader();

            lock (patientLock)
            {
                List<Patient> patients = patientReader.ReadPatients(patientsFilename);
                Patients = patients;
            }
        }

        public PatientLogic()
        {
        }

        public List<Patient> GetPatients()
        {
            lock (patientLock)
            {
                return Patients;
            }
        }

        public void AddPatient(Patient patient)
        {
            patient.Id = Guid.NewGuid().ToString();
            lock (patientLock)
            {
                Patients.Add(patient);
                SavePatientToJsonFile(patientsFilename);
            }
        }

        public void SavePatientToJsonFile(string filename)
        {
            lock (patientLock)
            {
                PatientWriter patientWriter = new PatientWriter();
                patientWriter.WritePatientsToJsonFile(Patients, filename);
            }
        }

        public Patient GetPatientById(string Id)
        {
            lock (patientLock)
            {
                foreach (Patient patient in Patients)
                {
                    if (patient.Id == Id)
                    {
                        return patient;
                    }
                }
            }
            return null;
        }

        public Patient GetPatientByPesel(string pesel)
        {
            lock (patientLock)
            {
                foreach (Patient patient in Patients)
                {
                    if (patient.Pesel == pesel)
                    {
                        return patient;
                    }
                }
            }
            return null;
        }
        public void RemovePatient(string Email)
        {
            lock (patientLock)
            {
                Patients.RemoveAll(x => x.Email == Email);
                SavePatientToJsonFile(patientsFilename);
            }
        }
    }
}
