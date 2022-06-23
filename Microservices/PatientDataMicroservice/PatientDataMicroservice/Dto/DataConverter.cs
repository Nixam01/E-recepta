using Newtonsoft.Json;

namespace PatientDataMicroservice
{
    public static class DataConverter
    {
        public static PatientData ConvertToPatientData(this Patient patient)
        {
            string data_str = patient.BirthDate.ToString("dd/MM/yyyy");
            return new PatientData()
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BirthDate = data_str,
                Email = patient.Email,
                Pesel = patient.Pesel,
            };
        }

        public static PatientData ConvertJsonToPatient(string json)
        {
            return JsonConvert.DeserializeObject<PatientData>(json);
        }

        public static Patient ConvertPatientDataToPatient(this PatientData patientData)
        {
            return new Patient(patientData.Id, patientData.FirstName, patientData.LastName, DateTime.Parse(patientData.BirthDate), patientData.Email,
                patientData.Pesel);
        }
    }
}
