namespace PatientApplicationMicroservice
{
    public class DoctorApplicationHandler : IDoctorApplicationHandler
    {
        private readonly IDoctorDataServiceClient DoctorDataServiceClient;

        public DoctorApplicationHandler(IDoctorDataServiceClient doctorDataServiceClient)
        {
            this.DoctorDataServiceClient = doctorDataServiceClient;
        }
        public async Task<IEnumerable<DoctorData>> GetAllDoctors()
        {
            return await DoctorDataServiceClient.GetAllDoctors();
        }

        public async Task<DoctorData> GetDoctorById(string id)
        {
            return await DoctorDataServiceClient.GetDoctorById(id);
        }

        public async Task<IEnumerable<DoctorData>> GetDoctorsBySpecialisation(string specialisation)
        {
            return await DoctorDataServiceClient.GetDoctorsBySpecialisation(specialisation);
        }
    }
}
