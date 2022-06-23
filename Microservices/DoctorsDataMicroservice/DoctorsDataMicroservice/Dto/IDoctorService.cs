namespace DoctorsDataMicroservice
{
    public interface IDoctorService
    {
        public List<DoctorData> GetDoctors();
        public void AddDoctor(DoctorData doctorData);
        public DoctorData GetDoctorById(string id);
        public List<DoctorData> GetDoctorsBySpecialisation(string specialisation);
        public void RemoveDoctor(string email);

    }
}
