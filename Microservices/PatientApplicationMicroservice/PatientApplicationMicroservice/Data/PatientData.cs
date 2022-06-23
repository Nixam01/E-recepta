namespace PatientApplicationMicroservice
{
    public class PatientData
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string Pesel { get; set; }

        public PatientData() { }

        public PatientData(string Id, string firstName, string lastName, string birthDate, string email, string pesel)
        {
            this.Id = Id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Email = email;
            this.Pesel = pesel;
        }

        public PatientData(string firstName, string lastName, string birthDate, string email, string pesel)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Email = email;
            this.Pesel = pesel;
        }
    }
}
