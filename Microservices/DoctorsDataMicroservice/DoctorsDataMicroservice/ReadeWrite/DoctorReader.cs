using Newtonsoft.Json;

namespace DoctorsDataMicroservice
{
    public class DoctorReader
    {
        public List<Doctor> ReadDoctors(string filename)
        {
            switch (GetFormat(filename))
            {
                case FileFormat.Json:
                    return ReadDoctorsJson(filename);

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

        public List<Doctor> ReadDoctorsJson(string filename)
        {
            List<Doctor> doctors = new List<Doctor>();

            using (StreamReader reader = File.OpenText(filename))
            {
                string json = reader.ReadToEnd();

                doctors = ConvertJsonToDocotrs(json);

            }
            return doctors;
        }

        public List<Doctor> ConvertJsonToDocotrs(string json)
        {
            return JsonConvert.DeserializeObject<List<Doctor>>(json);
        }
    }
}
