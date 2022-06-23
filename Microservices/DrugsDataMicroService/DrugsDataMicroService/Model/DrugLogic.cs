namespace DrugsDataMicroService
{
    public class DrugLogic :IDrug
    {
        private static List<Drug> Drugs;

        private static readonly object drugLock = new object();

        private const string drugFilename = "JsonStorage/drugs.json";

        static DrugLogic()
        {
            DrugReader drugReader = new DrugReader();

            lock (drugLock)
            {
                List<Drug> drugs = drugReader.ReadDrugs(drugFilename);
                Drugs = drugs;
            }
        }

        public DrugLogic()
        {

        }
        public List<Drug> GetDrugs()
        {
            lock (drugLock)
            {
                return Drugs;
            }
        }
        public void AddDrug(Drug drug)
            {
                drug.Id = Guid.NewGuid().ToString();
                lock (drugLock)
                {
                    Drugs.Add(drug);
                    SaveDrugToJsonFile(drugFilename);
                }
            }
        public void SaveDrugToJsonFile(string filename)
        {
            lock (drugLock)
            {
                DrugWriter drugWriter = new DrugWriter();
                drugWriter.WriteDrugsToJsonFile(Drugs, filename);
            }
        }
        public Drug GetDrugById(string Id)
        {
            lock (drugLock)
            {
                foreach(Drug drug in Drugs)
                {
                    if(drug.Id == Id)
                    {
                        return drug;
                    }
                }
            }
            return null;
        }
        public List<Drug> GetDrugsByType(DrugType type)
        {
            List<Drug> drugList = new List<Drug>();
            lock (drugLock)
            {
                foreach(Drug drug in Drugs)
                {
                    if (drug.DrugType.Equals(type))
                    {
                        drugList.Add(drug);
                    }
                }
                return drugList;
            }
        }
        public void RemoveDrug(string Id)
        {
            lock (drugLock)
            {
                Drugs.RemoveAll(x => x.Id == Id);
                SaveDrugToJsonFile(drugFilename);
            }
        }
    }
}
