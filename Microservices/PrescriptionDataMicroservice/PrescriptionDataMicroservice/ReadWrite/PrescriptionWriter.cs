using Newtonsoft.Json;

namespace PrescriptionDataMicroservice
{
    public class PrescriptionWriter
    {
        public void WritePrescriptionsToJsonFile(List<Prescription> prescriptions, string fileName)
        {
            string json = JsonConvert.SerializeObject(prescriptions, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
    }
}
