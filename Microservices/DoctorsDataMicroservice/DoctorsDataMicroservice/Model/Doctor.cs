using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DoctorsDataMicroservice
{
    public class Doctor
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

        [JsonProperty("DoctorSpecialisation")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DoctorSpecialisation Specialisation { get; set; }

        public Doctor(string Id, string firstName, string lastName, DateTime birthDate, string email, DoctorSpecialisation specialisation)
        {
            this.Id = Id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Email = email;
            this.Specialisation = specialisation;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}): {2}, {3}, {4:d}, {5}", "Doctor", Specialisation.ToString(), FirstName, LastName, BirthDate, Email);
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
