namespace AppModels
{
    public class DoctorData
    {
        public string? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string Specialisation { get; set; }

        public DoctorData() { }

        public DoctorData(string Id, string firstName, string lastName, string birthDate, string email, string specialisation)
        {
            this.Id = Id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Email = email;
            this.Specialisation = specialisation;
        }

        public DoctorData(string firstName, string lastName, string birthDate, string email, string specialisation)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Email = email;
            this.Specialisation = specialisation;
        }
    }
}
