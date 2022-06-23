namespace DoctorApplicationMicroservice
{
    public interface IPrescriptionDataServiceClient
    {
        Task<IEnumerable<PrescriptionData>> GetAllPrescriptions();
        Task<PrescriptionData> GetPrescriptionById(string id);
        Task<IEnumerable<PrescriptionData>> GetPrescriptionsByDoctorId(string id);
        Task<IEnumerable<PrescriptionData>> GetPrescriptionsByPatientId(string id);
        void AddPrescription(PrescriptionData prescriptionData);
        void RemovePrescription(string id);
    }
}
