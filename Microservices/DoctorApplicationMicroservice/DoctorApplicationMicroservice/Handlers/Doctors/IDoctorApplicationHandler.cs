namespace DoctorApplicationMicroservice
{
    public interface IDoctorApplicationHandler
    {
        Task<IEnumerable<DoctorData>> GetAllDoctors();
        Task<DoctorData> GetDoctorById(string id);
        Task<IEnumerable<DoctorData>> GetDoctorsBySpecialisation(string specialisation);
        void AddDoctor(DoctorData doctorData);
        void RemoveDoctor(string Id);
    }
}
