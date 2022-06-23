using System.Collections.Generic;

namespace AppModels
{
    public interface IDoctor
    {
        List<DrugData> GetAllDrugs();
        List<PrescriptionDataFull> GetPrescriptionsByPesel(string pesel);
        List<DoctorData> GetAllDoctors();
        List<PatientData> GetAllPatients();
        DoctorData GetDoctorById(string id);
    }
}
