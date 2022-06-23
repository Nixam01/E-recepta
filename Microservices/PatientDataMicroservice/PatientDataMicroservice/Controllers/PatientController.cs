using Microsoft.AspNetCore.Mvc;

namespace PatientDataMicroservice
{
    [ApiController]
    [Route("Patients")]
    public class PatientController : ControllerBase, IPatientService
    {
        private readonly ILogger<PatientController> logger;
        private readonly IPatient patientLogic;

        public PatientController(ILogger<PatientController> logger)
        {
            this.logger = logger;
            this.patientLogic = new PatientLogic();
        }

        [HttpGet]
        [Route("GetAll")]
        public List<PatientData> GetPatients()
        {
            List<Patient> patients = this.patientLogic.GetPatients();
            return patients.Select(patient => patient.ConvertToPatientData()).ToList();
        }

        [HttpPost]
        [Route("")]
        public void AddPatient(PatientData patientData)
        {
            this.patientLogic.AddPatient(DataConverter.ConvertPatientDataToPatient(patientData));
        }

        [HttpGet]
        [Route("GetById")]
        public PatientData GetById(string id)
        {
            Patient patient = this.patientLogic.GetPatientById(id);
            if (patient == null)
            {
                //var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                //{
                //    Content = new StringContent(string.Format("No patient with ID = {0}", id)),
                //    ReasonPhrase = "Patient with ID Not Found"
                //};
                //throw new System.Web.Http.HttpResponseException(resp);
                return null;
            }
            return patient.ConvertToPatientData();
        }

        [HttpGet]
        [Route("GetByPesel")]
        public PatientData GetByPesel(string pesel)
        {
            Patient patient = this.patientLogic.GetPatientByPesel(pesel);
            if (patient == null)
            {
                return null;
            }
            return patient.ConvertToPatientData();
        }
        [HttpPost]
        [Route("RemovePatient")]
        public void RemovePatient(string email)
        {
            this.patientLogic.RemovePatient(email);
        }
    }
}