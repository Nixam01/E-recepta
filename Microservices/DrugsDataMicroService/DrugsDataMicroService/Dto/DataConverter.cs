using Newtonsoft.Json;

namespace DrugsDataMicroService
{
    public static class DataConverter
    {
        public static DrugData ConvertToDrugData(this Drug drug)
        {
            string type = drug.DrugType.ToString();
            return new DrugData()
            {
                Id = drug.Id,
                Name = drug.Name,
                Type = type,
                NeedPrescription = drug.NeedPrescription
            };

        }
        
        public static DrugData ConvertJsonToDrug(string json)
        {
            return JsonConvert.DeserializeObject<DrugData>(json);
        }
        public static Drug ConvertDrugDataToDrug(this DrugData drugData)
        {
            return new Drug(drugData.Id, drugData.Name, Enum.Parse<DrugType>(drugData.Type), drugData.NeedPrescription);
        }
    }
}
