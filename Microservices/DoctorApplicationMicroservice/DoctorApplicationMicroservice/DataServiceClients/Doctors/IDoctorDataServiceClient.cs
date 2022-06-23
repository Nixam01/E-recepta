namespace DoctorApplicationMicroservice
{
    public interface IDoctorDataServiceClient
    {
        Task<IEnumerable<DoctorData>> GetAllDoctors();
        Task<DoctorData> GetDoctorById(string id);
        Task<IEnumerable<DoctorData>> GetDoctorsBySpecialisation(string specialisation);
        void AddDoctor(DoctorData doctorData);
        void RemoveDoctor(string id);
    }
}
