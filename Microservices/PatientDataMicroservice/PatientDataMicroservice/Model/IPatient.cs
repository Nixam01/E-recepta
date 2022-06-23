namespace PatientDataMicroservice
{
    public interface IPatient
    {
        public List<Patient> GetPatients();
        public void AddPatient(Patient patient);
        public Patient GetPatientById(string Id);
        public Patient GetPatientByPesel(string Pesel);
        public void RemovePatient(string Email);
    }
}
