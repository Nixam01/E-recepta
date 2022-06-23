namespace PatientApplicationMicroservice
{
    public class PrescriptionData
    {
        public string? Id { get; set; }
        public string DateCreated { get; set; }
        public string DateValidThrough { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public Dictionary<string, string> Content { get; set; }

        public PrescriptionData()
        {
        }
        public PrescriptionData(string Id, string DateCreated, string DateValidThrough, string DoctorId, string PatientId, Dictionary<string, string> Content)
        {
            this.Id = Id;
            this.DateCreated = DateCreated;
            this.DateValidThrough = DateValidThrough;
            this.DoctorId = DoctorId;
            this.PatientId = PatientId;
            this.Content = Content;
        }

        public PrescriptionData(string DateCreated, string DateValidThrough, string DoctorId, string PatientId, Dictionary<string, string> Content)
        {
            this.DateCreated = DateCreated;
            this.DateValidThrough = DateValidThrough;
            this.DoctorId = DoctorId;
            this.PatientId = PatientId;
            this.Content = Content;
        }
    }
}
