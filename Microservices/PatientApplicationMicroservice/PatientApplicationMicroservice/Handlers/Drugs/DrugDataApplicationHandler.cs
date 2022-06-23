namespace PatientApplicationMicroservice
{
    public class DrugApplicationHandler : IDrugApplicationHandler
    {
        private readonly IDrugDataServiceClient DrugDataServiceClient;

        public DrugApplicationHandler(IDrugDataServiceClient drugDataServiceClient)
        {
            this.DrugDataServiceClient = drugDataServiceClient;
        }
        public async Task<IEnumerable<DrugData>> GetAllDrugs()
        {
            return await DrugDataServiceClient.GetAllDrugs();
        }

        public async Task<DrugData> GetDrugById(string id)
        {
            return await DrugDataServiceClient.GetDrugById(id);
        }

        public async Task<IEnumerable<DrugData>> GetDrugsByType(string type)
        {
            return await DrugDataServiceClient.GetDrugsByType(type);
        }
    }
}

