using System.Collections.Generic;

namespace AppModels
{
    public partial class Model : IData
    {
        public string SearchText
        {
            get { return this.searchText; }
            set
            {
                this.searchText = value;

                this.RaisePropertyChanged("SearchText");
            }
        }
        private string searchText;

        public List<DrugData> DrugList
        {
            get { return this.drugList; }
            private set
            {
                this.drugList = value;

                this.RaisePropertyChanged("DrugList");
            }
        }
        private List<DrugData> drugList = new List<DrugData>();

        public DrugData SelectedDrug
        {
            get { return this.selectedDrug; }
            set
            {
                this.selectedDrug = value;

                this.RaisePropertyChanged("SelectedDrug");
            }
        }
        private DrugData selectedDrug;


        public List<DoctorData> DoctorList
        {
            get { return this.doctorList; }
            private set
            {
                this.doctorList = value;

                this.RaisePropertyChanged("DoctorList");
            }
        }
        private List<DoctorData> doctorList = new List<DoctorData>();

        public DoctorData SelectedDoctor
        {
            get { return this.selectedDoctor; }
            set
            {
                this.selectedDoctor = value;

                this.RaisePropertyChanged("SelectedDoctor");
            }
        }
        private DoctorData selectedDoctor;

        public List<PatientData> PatientList
        {
            get { return this.patientList; }
            private set
            {
                this.patientList = value;

                this.RaisePropertyChanged("DoctorList");
            }
        }
        private List<PatientData> patientList = new List<PatientData>();

        public PatientData SelectedPatient
        {
            get { return this.selectedPatient; }
            set
            {
                this.selectedPatient = value;

                this.RaisePropertyChanged("SelectedDoctor");
            }
        }
        private PatientData selectedPatient;

        public List<PrescriptionDataFull> PrescriptionList
        {
            get { return this.prescriptionList; }
            private set
            {
                this.prescriptionList = value;

                this.RaisePropertyChanged("PrescriptionList");
            }
        }
        private List<PrescriptionDataFull> prescriptionList = new List<PrescriptionDataFull>();

        public PrescriptionDataFull SelectedPrescription
        {
            get { return this.selectedPrescription; }
            set
            {
                this.selectedPrescription = value;

                this.RaisePropertyChanged("SelectedPrescription");
            }
        }
        private PrescriptionDataFull selectedPrescription;
    }

}
