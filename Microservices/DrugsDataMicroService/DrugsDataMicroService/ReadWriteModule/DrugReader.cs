using Newtonsoft.Json;

namespace DrugsDataMicroService

{
    public class DrugReader
    {
        public List<Drug> ReadDrugs(string filename)
        {
            switch (GetFormat(filename))
            {
                case FileFormat.Json:
                    return ReadDrugsJson(filename);

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
        public List<Drug> ReadDrugsJson(string filename)
        {
            List<Drug> drugs = new List<Drug>();

            using (StreamReader reader = File.OpenText(filename))
            {
                string json = reader.ReadToEnd();

                drugs = ConvertJsonToDrugs(json);

            }
            return drugs;
        }
        public List<Drug> ConvertJsonToDrugs(string json)
        {
            return JsonConvert.DeserializeObject<List<Drug>>(json);
        }
    }
}
