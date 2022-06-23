using Microsoft.AspNetCore.Mvc;

namespace PatientApplicationMicroservice
{
    [ApiController]
    [Route("")]
    public class PatientApplicationController : ControllerBase
    {
        private readonly ILogger<PatientApplicationController> logger;
        private readonly IPatientApplicationHandler patientApplicationHandler;
        private readonly IDrugApplicationHandler drugApplicationHandler;
        private readonly IPrescriptionApplicationHandler prescriptionApplicationHandler;
        private readonly IDoctorApplicationHandler doctorApplicationHandler;
        private static string currentPesel = "";
        private static string currentId = "";

        public PatientApplicationController(ILogger<PatientApplicationController> logger, IPatientApplicationHandler patientApplicationHandler,
            IDrugApplicationHandler drugApplicationHandler, IPrescriptionApplicationHandler prescriptionApplicationHandler,
            IDoctorApplicationHandler doctorApplicationHandler)
        {
            this.logger = logger;
            this.patientApplicationHandler = patientApplicationHandler;
            this.drugApplicationHandler = drugApplicationHandler;
            this.prescriptionApplicationHandler = prescriptionApplicationHandler;
            this.doctorApplicationHandler = doctorApplicationHandler;
        }

        [HttpGet]
        [Route("Prescriptions/GetAllPrescriptions")]
        public async Task<IEnumerable<PrescriptionData>> GetAllPrescriptions()
        {
            return await prescriptionApplicationHandler.GetAllPrescriptions();
        }

        [HttpGet]
        [Route("Prescriptions/GetMyPrescriptions")]
        public async Task<IEnumerable<PrescriptionDataFull>> GetMyPrescriptions(string pesel)
        {
            return await prescriptionApplicationHandler.GetPrescriptionsByPatientPesel(pesel);
        }

        [HttpPost]
        [Route("Prescriptions/OrderPrescription")]
        public void OrderPrescription(string id)
        {
            prescriptionApplicationHandler.OrderPrescription(id);
        }

        [HttpGet]
        [Route("Drugs/GetAllDrugs")]
        public async Task<IEnumerable<DrugData>> GetAllDrugs()
        {
            return await drugApplicationHandler.GetAllDrugs();
        }

        [HttpPost]
        [Route("Patients/EditContactData")]
        public void EditContactData(string pesel)
        {
            currentPesel = pesel;
            currentId = patientApplicationHandler.GetPatientByPesel(pesel).Result.Id;
        }

        [HttpGet]
        [Route("Patients/GetAllPatients")]
        public async Task<IEnumerable<PatientData>> GetAllPatients()
        {
            return await patientApplicationHandler.GetAllPatients();
        }

        [HttpGet]
        [Route("Doctors/GetAll")]
        public async Task<IEnumerable<DoctorData>> GetAllDoctors()
        {
            return await doctorApplicationHandler.GetAllDoctors();
        }

        [HttpGet]
        [Route("Doctors/GetById")]
        public async Task<DoctorData> GetDoctorById(string id)
        {
            return await doctorApplicationHandler.GetDoctorById(id);
        }
    }
}
