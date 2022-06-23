namespace PrescriptionDataMicroservice
{
    public interface IPrescription
    {
        public List<Prescription> GetPrescriptions();
        public void AddPrescription(Prescription prescription);
        public Prescription GetPrescriptionById(string Id);
        public List<Prescription> GetPrescriptionByDoctorID(string doctorID);
        public List<Prescription> GetPrescriptionByPatientID(string patientID);
        public void RemovePrescription(string name);
    }
}
