namespace DoctorsDataMicroservice
{
    public interface IDoctor
    {
        public List<Doctor> GetDoctors();
        public void AddDoctor(Doctor doctor);
        public Doctor GetDoctorById(string Id);
        public List<Doctor> GetDoctorsBySpecialisation(DoctorSpecialisation specialisation);
        public void RemoveDoctor(string email);
    }
}
