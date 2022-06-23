using Newtonsoft.Json;

namespace PatientDataMicroservice
{
    public class PatientReader
    {
        public List<Patient> ReadPatients(string filename)
        {
            switch (GetFormat(filename))
            {
                case FileFormat.Json:
                    return ReadPatientsJson(filename);

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

        public List<Patient> ReadPatientsJson(string filename)
        {
            List<Patient> patients = new List<Patient>();

            using (StreamReader reader = File.OpenText(filename))
            {
                string json = reader.ReadToEnd();

                patients = ConvertJsonToPatients(json);

            }
            return patients;
        }

        public List<Patient> ConvertJsonToPatients(string json)
        {
            return JsonConvert.DeserializeObject<List<Patient>>(json);
        }
    }
}
