using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PrescriptionDataMicroservice
{
    public class Prescription
    {
        public string Id { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DateCreated { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DateValidThrough { get; set; }

        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public Dictionary<string, string> Content { get; set; }

        public Prescription(string Id, DateTime dateCreated, DateTime dateValidThrough, string doctorId, string patientId, Dictionary<string, string> content)
        {
            this.Id = Id;
            this.DateCreated = dateCreated;
            this.DateValidThrough = dateValidThrough;
            this.DoctorId = doctorId;
            this.PatientId = patientId;
            this.Content = content;
        }

        public override string ToString()
        {
            return String.Format("Prescription: {0:d}, {1:d}, {2}, {3}; Content: {4}", DateCreated, DateValidThrough, DoctorId, PatientId, Content);
        }
    }

    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "dd.MM.yyyy";
        }
    }
}
