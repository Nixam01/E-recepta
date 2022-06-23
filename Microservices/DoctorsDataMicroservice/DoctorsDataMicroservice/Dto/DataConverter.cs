using Newtonsoft.Json;

namespace DoctorsDataMicroservice
{
    public static class DataConverter
    {
        public static DoctorData ConvertToDoctorData(this Doctor doctor)
        {
            string data_str = doctor.BirthDate.ToString("dd/MM/yyyy");
            string specialization = doctor.Specialisation.ToString();
            return new DoctorData()
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                BirthDate = data_str,
                Email = doctor.Email,
                Specialisation = specialization
            };
        }

        public static DoctorData ConvertJsonToDoctor(string json)
        {
            return JsonConvert.DeserializeObject<DoctorData>(json);
        }

        public static Doctor ConvertDoctorDataToDoctor(this DoctorData doctorData)
        {
            return new Doctor(doctorData.Id, doctorData.FirstName, doctorData.LastName, DateTime.Parse(doctorData.BirthDate), doctorData.Email,
                Enum.Parse<DoctorSpecialisation>(doctorData.Specialisation));
        }
    }
}
