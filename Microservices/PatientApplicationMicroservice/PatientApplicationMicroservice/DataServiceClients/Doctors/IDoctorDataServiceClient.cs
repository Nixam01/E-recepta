namespace PatientApplicationMicroservice
{
    public interface IDoctorDataServiceClient
    {
        Task<IEnumerable<DoctorData>> GetAllDoctors();
        Task<DoctorData> GetDoctorById(string id);
        Task<IEnumerable<DoctorData>> GetDoctorsBySpecialisation(string specialisation);
    }
}
