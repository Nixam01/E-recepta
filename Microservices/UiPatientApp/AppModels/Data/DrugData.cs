namespace AppModels
{
    public class DrugData
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool NeedPrescription { get; set; }

        public DrugData()
        {

        }
        public DrugData(string Id, string name, string type, bool needPrescription)
        {
            this.Id = Id;
            this.Name = name;
            this.Type = type;
            this.NeedPrescription = needPrescription;
        }

        public DrugData(string name, string type, bool needPrescription)
        {
            this.Name = name;
            this.Type = type;
            this.NeedPrescription = needPrescription;
        }
    }

}
