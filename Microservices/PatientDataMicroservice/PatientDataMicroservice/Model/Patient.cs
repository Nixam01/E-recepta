using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PatientDataMicroservice
{
    public class Patient
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }

        public Patient(string Id, string firstName, string lastName, DateTime birthDate, string email, string pesel)
        {
            this.Id = Id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Email = email;
            this.Pesel = pesel;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}, {2}, {3:d}, {4}, {5}", "Patient", FirstName, LastName, BirthDate, Email, Pesel);
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
