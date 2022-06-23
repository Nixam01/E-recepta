using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DrugsDataMicroService
{
    public class Drug
    {

        public string Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("DrugType")]
        [JsonConverter(typeof(StringEnumConverter))]

        public DrugType DrugType { get; set; }

        public bool NeedPrescription { get; set; }

        public Drug(string id, string name, DrugType type, bool needPrescription)
        {
            this.Id = id;
            this.Name = name;
            this.DrugType = type;
            this.NeedPrescription = needPrescription;

        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", "Drug", DrugType.ToString(), Name, NeedPrescription);
        }
    }
}
