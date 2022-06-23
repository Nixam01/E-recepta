namespace PatientDataMicroservice
{
    public interface IPatientService
    {
        public List<PatientData> GetPatients();
        public void AddPatient(PatientData patientData);
        public PatientData GetById(string id);
        public PatientData GetByPesel(string pesel);
        public void RemovePatient(string Email);
    }
}
