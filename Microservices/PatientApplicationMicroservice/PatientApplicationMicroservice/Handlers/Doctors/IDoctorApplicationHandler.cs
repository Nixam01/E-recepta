namespace PatientApplicationMicroservice
{
    public interface IDoctorApplicationHandler
    {
        Task<IEnumerable<DoctorData>> GetAllDoctors();
        Task<DoctorData> GetDoctorById(string id);
        Task<IEnumerable<DoctorData>> GetDoctorsBySpecialisation(string specialisation);
    }
}
