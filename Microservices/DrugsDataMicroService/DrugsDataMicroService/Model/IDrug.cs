namespace DrugsDataMicroService
{
    public interface IDrug
    {
        public List<Drug> GetDrugs();
        public void AddDrug(Drug drug);
        public Drug GetDrugById(string Id);

        public List<Drug> GetDrugsByType(DrugType type);
        public void RemoveDrug(string Id);
    }
}
