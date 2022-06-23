namespace PatientApplicationMicroservice
{
    public interface IDrugDataServiceClient
    {
        Task<IEnumerable<DrugData>> GetAllDrugs();
        Task<DrugData> GetDrugById(string id);
        Task<IEnumerable<DrugData>> GetDrugsByType(string type);
    }
}
