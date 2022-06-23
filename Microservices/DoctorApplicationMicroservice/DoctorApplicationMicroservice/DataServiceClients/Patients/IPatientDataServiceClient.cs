namespace DoctorApplicationMicroservice
{
    public interface IPatientDataServiceClient
    {
        Task<IEnumerable<PatientData>> GetAllPatients();
        Task<PatientData> GetPatientById(string id);
        Task<PatientData> GetPatientByPesel(string pesel);
        void AddPatient(PatientData patientData);
        void RemovePatient(string id);
    }
}
