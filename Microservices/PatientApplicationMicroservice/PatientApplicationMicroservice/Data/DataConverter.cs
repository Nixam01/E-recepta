using Newtonsoft.Json;

namespace PatientApplicationMicroservice
{
    public static class DataConverter
    {
        public static DoctorData ConvertJsonToDoctorData(string json)
        {
            return JsonConvert.DeserializeObject<DoctorData>(json);
        }

        public static PatientData ConvertJsonToPatientData(string json)
        {
            return JsonConvert.DeserializeObject<PatientData>(json);
        }
    }
}
