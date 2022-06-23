using System.Collections.Generic;

namespace AppModels
{
    public interface IPatient
    {
        List<DrugData> GetAllDrugs();
        List<PrescriptionDataFull> GetPrescriptionsByPesel(string pesel);
        List<DoctorData> GetAllDoctors();
        DoctorData GetDoctorById(string id);
    }
}
