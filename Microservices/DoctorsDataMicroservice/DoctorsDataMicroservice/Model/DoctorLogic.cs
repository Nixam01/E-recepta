namespace DoctorsDataMicroservice
{
    public class DoctorLogic : IDoctor
    {
        private static List<Doctor> Doctors;

        private static readonly object doctorLock = new object();

        private const string doctorsFilename = "JsonStorage/doctors.json";

        static DoctorLogic()
        {
            DoctorReader doctorReader = new DoctorReader();

            lock (doctorLock)
            {
                List<Doctor> doctors = doctorReader.ReadDoctors(doctorsFilename);
                Doctors = doctors;
            }
        }

        public DoctorLogic()
        {
        }

        public List<Doctor> GetDoctors()
        {
            lock (doctorLock)
            {
                return Doctors;
            }
        }

        public void AddDoctor(Doctor doctor)
        {
            doctor.Id = Guid.NewGuid().ToString();
            lock (doctorLock)
            {
                Doctors.Add(doctor);
                SaveDoctorToJsonFile(doctorsFilename);
            }
        }

        public void SaveDoctorToJsonFile(string filename)
        {
            lock (doctorLock)
            {
                DoctorWriter doctorWriter = new DoctorWriter();
                doctorWriter.WriteDoctorsToJsonFile(Doctors, filename);
            }
        }

        public Doctor GetDoctorById(string Id)
        {
            lock (doctorLock)
            {
                foreach (Doctor doctor in Doctors)
                {
                    if (doctor.Id == Id)
                    {
                        return doctor;
                    }
                }
            }
            return null;
        }

        public List<Doctor> GetDoctorsBySpecialisation(DoctorSpecialisation specialisation)
        {
            List<Doctor> doctors = new List<Doctor>();
            lock (doctorLock)
            {
                foreach (Doctor doctor in Doctors)
                {
                    if (doctor.Specialisation.Equals(specialisation))
                    {
                        doctors.Add(doctor);
                    }
                }
                return doctors;
            }
        }
        public void RemoveDoctor(string email)
        {
            lock (doctorLock)
            {
                Doctors.RemoveAll(x => x.Email == email);
                SaveDoctorToJsonFile(doctorsFilename);
            }
        }
    }
}
