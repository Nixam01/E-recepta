using Newtonsoft.Json;

namespace PrescriptionDataMicroservice
{
    public class PrescriptionReader
    {
        public List<Prescription> ReadPrescriptions(string filename)
        {
            switch (GetFormat(filename))
            {
                case FileFormat.Json:
                    return ReadPrescriptionsJson(filename);

                case FileFormat.Txt:
                    throw new ArgumentOutOfRangeException();

                case FileFormat.Xml:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static FileFormat GetFormat(string filename)
        {
            const string JsonExt = ".json";
            const string XmlExt = ".xml";

            FileFormat fileFormat = FileFormat.Txt;

            if (filename.EndsWith(JsonExt))
            {
                fileFormat = FileFormat.Json;
            }
            else if (filename.EndsWith(XmlExt))
            {
                fileFormat = FileFormat.Xml;
            }
            return fileFormat;
        }

        public List<Prescription> ReadPrescriptionsJson(string filename)
        {
            List<Prescription> prescriptions = new List<Prescription>();

            using (StreamReader reader = File.OpenText(filename))
            {
                string json = reader.ReadToEnd();

                prescriptions = ConvertJsonToPrescriptions(json);

            }
            return prescriptions;
        }

        public List<Prescription> ConvertJsonToPrescriptions(string json)
        {
            return JsonConvert.DeserializeObject<List<Prescription>>(json);
        }
    }
}
