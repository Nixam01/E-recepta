using Newtonsoft.Json;

namespace DoctorsDataMicroservice
{
    public class DoctorWriter
    {
        public void WriteDoctorsToJsonFile(List<Doctor> doctors, string fileName)
        {
            string json = JsonConvert.SerializeObject(doctors, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
    }
}
