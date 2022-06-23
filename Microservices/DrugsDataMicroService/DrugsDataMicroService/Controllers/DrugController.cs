using Microsoft.AspNetCore.Mvc;

namespace DrugsDataMicroService
{
    [ApiController]
    [Route("Drugs")]
    public class DrugController : ControllerBase, IDrugService
    {
        private readonly ILogger<DrugController> logger;
        private readonly IDrug drugLogic;

        public DrugController(ILogger<DrugController> logger)
        {
            this.logger = logger;
            this.drugLogic = new DrugLogic();
        }

        [HttpGet]
        [Route("GetAll")]

        public List<DrugData> GetDrugs()
        {
            List<Drug> drugs = this.drugLogic.GetDrugs();
            return drugs.Select(drug => drug.ConvertToDrugData()).ToList();
        }
        [HttpPost]
        [Route("")]
        public void AddDrug(DrugData drugData)
        {
            this.drugLogic.AddDrug(DataConverter.ConvertDrugDataToDrug(drugData));
        }
        [HttpGet]
        [Route("GetById")]
        public DrugData GetDrugById(string id)
        {
            Drug drug = this.drugLogic.GetDrugById(id);
            if (drug == null)
            {
                return null;
            }
            return drug.ConvertToDrugData();
        }
        [HttpGet]
        [Route("GetByType")]
        public List<DrugData> GetDrugsByType(string type)
        {
            bool enumIsValid = Enum.TryParse(type, true, out DrugType drugtype);
            if (!enumIsValid)
            {
                return null;
            };

            List<Drug> drugs = this.drugLogic.GetDrugsByType(drugtype);
            return drugs.Select(drug => drug.ConvertToDrugData()).ToList();
        }
        [HttpPost]
        [Route("RemoveDrug")]
        public void RemoveDrug(string Id)
        {
            this.drugLogic.RemoveDrug(Id);
        }

    }
}