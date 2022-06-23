using Newtonsoft.Json;

namespace DrugsDataMicroService
{
    public class DrugWriter
    {
        public void WriteDrugsToJsonFile(List<Drug> drugs, string fileName)
        {
            string json = JsonConvert.SerializeObject(drugs, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
    }
}
