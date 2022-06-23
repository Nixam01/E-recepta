namespace PatientApplicationMicroservice
{
    public class PatientApplicationHandler : IPatientApplicationHandler
    {
        private readonly IPatientDataServiceClient PatientDataServiceClient;

        public PatientApplicationHandler(IPatientDataServiceClient patientDataServiceClient)
        {
            this.PatientDataServiceClient = patientDataServiceClient;
        }
        public async Task<IEnumerable<PatientData>> GetAllPatients()
        {
            return await PatientDataServiceClient.GetAllPatients();
        }

        public async Task<PatientData> GetPatientById(string id)
        {
            return await PatientDataServiceClient.GetPatientById(id);
        }

        public async Task<PatientData> GetPatientByPesel(string pesel)
        {
            return await PatientDataServiceClient.GetPatientByPesel(pesel);
        }
    }
}
