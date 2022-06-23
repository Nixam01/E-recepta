namespace PatientApplicationMicroservice
{
    public interface IPatientDataServiceClient
    {
        Task<IEnumerable<PatientData>> GetAllPatients();
        Task<PatientData> GetPatientById(string id);
        Task<PatientData> GetPatientByPesel(string pesel);
    }
}
