using System.Collections.Generic;

using System.ComponentModel;

namespace AppModels
{
    public interface IData : INotifyPropertyChanged
    {
        string SearchText { get; set; }

        List<DrugData> DrugList { get; }
        DrugData SelectedDrug { get; set; }

        List<DoctorData> DoctorList { get; }
        DoctorData SelectedDoctor { get; set; }

        List<PatientData> PatientList { get; }
        PatientData SelectedPatient { get; set; }

        List<PrescriptionDataFull> PrescriptionList { get; }
        PrescriptionDataFull SelectedPrescription { get; set; }
    }
}
