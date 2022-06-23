using Newtonsoft.Json;

namespace PrescriptionDataMicroservice
{
    public static class DataConverter
    {
        public static PrescriptionData ConvertToPrescriptionData(this Prescription prescription)
        {
            string data_str1 = prescription.DateCreated.ToString("dd/MM/yyyy");
            string data_str2 = prescription.DateValidThrough.ToString("dd/MM/yyyy");
            return new PrescriptionData(prescription.Id, data_str1, data_str2, prescription.DoctorId, prescription.PatientId, prescription.Content);
        }

        public static PrescriptionData ConvertJsonToPrescription(string json)
        {
            return JsonConvert.DeserializeObject<PrescriptionData>(json);
        }

        public static Prescription ConvertPrescriptionDataToPrescription(this PrescriptionData prescriptionData)
        {
            return new Prescription(prescriptionData.Id, DateTime.Parse(prescriptionData.DateCreated), DateTime.Parse(prescriptionData.DateValidThrough), prescriptionData.DoctorId, prescriptionData.PatientId, prescriptionData.Content);
        }
    }
}
