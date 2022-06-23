namespace AppModels
{
    public interface IOperations
    {
        void LoadDrugList();
        void LoadDoctorList();
        void LoadPatientList();
        void LoadPrescriptionList();
    }
}
