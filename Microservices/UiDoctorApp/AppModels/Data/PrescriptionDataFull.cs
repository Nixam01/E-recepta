using System.Collections.Generic;

namespace AppModels
{
    public class PrescriptionDataFull
    {
        public string? Id { get; set; }
        public string DateCreated { get; set; }
        public string DateValidThrough { get; set; }
        public DoctorData Doctor { get; set; }
        public PatientData Patient { get; set; }
        public Dictionary<string, string> Content { get; set; }

        public PrescriptionDataFull()
        {
        }
        public PrescriptionDataFull(string Id, string DateCreated, string DateValidThrough, DoctorData Doctor, PatientData Patient, Dictionary<string, string> Content)
        {
            this.Id = Id;
            this.DateCreated = DateCreated;
            this.DateValidThrough = DateValidThrough;
            this.Doctor = Doctor;
            this.Patient = Patient;
            this.Content = Content;
        }

        public PrescriptionDataFull(string DateCreated, string DateValidThrough, DoctorData Doctor, PatientData Patient, Dictionary<string, string> Content)
        {
            this.DateCreated = DateCreated;
            this.DateValidThrough = DateValidThrough;
            this.Doctor = Doctor;
            this.Patient = Patient;
            this.Content = Content;
        }
    }
}
