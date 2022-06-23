using Newtonsoft.Json;

namespace PatientDataMicroservice
{
    public class PatientWriter
    {
        public void WritePatientsToJsonFile(List<Patient> patients, string fileName)
        {
            string json = JsonConvert.SerializeObject(patients, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
    }
}
