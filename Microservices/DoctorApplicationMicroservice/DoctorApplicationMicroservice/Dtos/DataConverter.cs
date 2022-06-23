using Newtonsoft.Json;

namespace DoctorApplicationMicroservice
{
    public static class DataConverter
    {
        public static DoctorData ConvertJsonToDoctorData(string json)
        {
            return JsonConvert.DeserializeObject<DoctorData>(json);
        }
    }
}
