namespace PatientApplicationMicroservice
{
    public interface IPrescriptionApplicationHandler
    {
        Task<IEnumerable<PrescriptionDataFull>> GetAllFullPrescriptions();
        Task<PrescriptionDataFull> GetPrescriptionById(string id);
        void AddPrescription(PrescriptionData prescriptionData);
        //Task<IEnumerable<PrescriptionDataFull>> GetPrescriptionsByDoctorId(string id);
        Task<IEnumerable<PrescriptionDataFull>> GetPrescriptionsByPatientPesel(string pesel);
        Task<IEnumerable<PrescriptionData>> GetAllPrescriptions();
        void OrderPrescription(string id);
    }
}
