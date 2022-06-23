namespace DrugsDataMicroService
{
    public interface IDrugService
    {
        public List<DrugData> GetDrugs();
        public void AddDrug(DrugData drugData);
        public DrugData GetDrugById(string id);
        public List<DrugData> GetDrugsByType(string type);

        public void RemoveDrug(string id);
    }
}
