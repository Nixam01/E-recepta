namespace PrescriptionDataMicroservice
{
    public interface IPrescriptionService
    {
        public List<PrescriptionData> GetPrescriptions();
        public void AddPrescription(PrescriptionData prescriptionData);
        public PrescriptionData GetPrescriptionById(string Id);
        public List<PrescriptionData> GetPrescriptionByDoctorID(string doctorID);
        public List<PrescriptionData> GetPrescriptionByPatientID(string patientID);
        public void RemovePrescription(string Id);
    }
}
