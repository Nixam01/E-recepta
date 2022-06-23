namespace DoctorApplicationMicroservice
{
    public interface IDrugDataServiceClient
    {
        Task<IEnumerable<DrugData>> GetAllDrugs();
        Task<DrugData> GetDrugById(string id);
        Task<IEnumerable<DrugData>> GetDrugsByType(string type);
        void AddDrug(DrugData drugData);
        void RemoveDrug(string id);
    }
}
