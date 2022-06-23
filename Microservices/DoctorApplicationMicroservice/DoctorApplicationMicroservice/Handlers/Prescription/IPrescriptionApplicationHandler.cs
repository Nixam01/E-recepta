namespace DoctorApplicationMicroservice
{
    public interface IPrescriptionApplicationHandler
    {
        Task<IEnumerable<PrescriptionDataFull>> GetAllFullPrescriptions();
        Task<PrescriptionDataFull> GetPrescriptionById(string id);
        void AddPrescription(PrescriptionData prescriptionData);
        void RemovePrescription(string Id);
        //Task<IEnumerable<PrescriptionDataFull>> GetPrescriptionsByDoctorId(string id);
        //Task<IEnumerable<PrescriptionDataFull>> GetPrescriptionsByPatientId(string id);
    }
}
