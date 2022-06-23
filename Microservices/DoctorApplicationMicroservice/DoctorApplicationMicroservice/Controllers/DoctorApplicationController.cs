using Microsoft.AspNetCore.Mvc;

namespace DoctorApplicationMicroservice
{
    [ApiController]
    [Route("")]
    public class DoctorApplicationController : ControllerBase
    {
        private readonly ILogger<DoctorApplicationController> logger;
        private readonly IDoctorApplicationHandler doctorApplicationHandler;
        private readonly IPatientApplicationHandler patientApplicationHandler;
        private readonly IDrugApplicationHandler drugApplicationHandler;
        private readonly IPrescriptionApplicationHandler prescriptionApplicationHandler;

        public DoctorApplicationController(ILogger<DoctorApplicationController> logger, IDoctorApplicationHandler doctorApplicationHandler,
            IPatientApplicationHandler patientApplicationHandler, IDrugApplicationHandler drugApplicationHandler, IPrescriptionApplicationHandler prescriptionApplicationHandler)
        {
            this.logger = logger;
            this.doctorApplicationHandler = doctorApplicationHandler;
            this.patientApplicationHandler = patientApplicationHandler;
            this.drugApplicationHandler = drugApplicationHandler;
            this.prescriptionApplicationHandler = prescriptionApplicationHandler;
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

        [HttpGet]
        [Route("Doctors/GetBySpecialisation")]
        public async Task<IEnumerable<DoctorData>> GetDoctorsBySpecialisation(string specialisation)
        {
            return await doctorApplicationHandler.GetDoctorsBySpecialisation(specialisation);
        }

        [HttpGet]
        [Route("Patients/GetAll")]
        public async Task<IEnumerable<PatientData>> GetAllPatients()
        {
            return await patientApplicationHandler.GetAllPatients();
        }

        [HttpGet]
        [Route("Patients/GetById")]
        public async Task<PatientData> GetPatientById(string id)
        {
            return await patientApplicationHandler.GetPatientById(id);
        }

        [HttpGet]
        [Route("Patients/GetByPesel")]
        public async Task<PatientData> GetPatientByPesel(string pesel)
        {
            return await patientApplicationHandler.GetPatientByPesel(pesel);
        }

        [HttpGet]
        [Route("Drugs/GetAll")]
        public async Task<IEnumerable<DrugData>> GetAllDrugs()
        {
            return await drugApplicationHandler.GetAllDrugs();
        }

        [HttpGet]
        [Route("Drugs/GetById")]
        public async Task<DrugData> GetDrugById(string id)
        {
            return await drugApplicationHandler.GetDrugById(id);
        }

        [HttpGet]
        [Route("Drugs/GetByType")]
        public async Task<IEnumerable<DrugData>> GetDrugsByType(string type)
        {
            return await drugApplicationHandler.GetDrugsByType(type);
        }

        [HttpGet]
        [Route("Prescriptions/GetById")]
        public async Task<PrescriptionDataFull> GetPrescriptionById(string id)
        {
            return await prescriptionApplicationHandler.GetPrescriptionById(id);
        }

        [HttpGet]
        [Route("Prescriptions/GetAll")]
        public async Task<IEnumerable<PrescriptionDataFull>> GetAllFullPrescription()
        {
            return await prescriptionApplicationHandler.GetAllFullPrescriptions();
        }

        [HttpPost]
        [Route("Prescriptions/AddPrescription")]
        public async void AddPrescription(PrescriptionData prescriptionData)
        {
            prescriptionApplicationHandler.AddPrescription(prescriptionData);
        }
        [HttpPost]
        [Route("Prescriptions/RemovePrescription")]
        public async void RemovePrescription(string Id)
        {
            prescriptionApplicationHandler.RemovePrescription(Id);
        }
        [HttpPost]
        [Route("Drugs/AddDrug")]
        public async void AddDrug(DrugData drugData)
        {
            drugApplicationHandler.AddDrug(drugData);
        }
        [HttpPost]
        [Route("Drugs/RemoveDrug")]
        public async void RemoveDrug(string Id)
        {
            drugApplicationHandler.RemoveDrug(Id);
        }
        [HttpPost]
        [Route("Patients/AddPatient")]
        public async void AddPatient(PatientData patientData)
        {
            patientApplicationHandler.AddPatient(patientData);
        }
        [HttpPost]
        [Route("Patients/RemovePatient")]
        public async void RemovePatient(string Id)
        {
            patientApplicationHandler.RemovePatient(Id);
        }
        [HttpPost]
        [Route("Patients/AddDoctor")]
        public async void AddDoctor(DoctorData doctorData)
        {
            doctorApplicationHandler.AddDoctor(doctorData);
        }
        [HttpPost]
        [Route("Patients/RemoveDoctor")]
        public async void RemoveDoctor(string Id)
        {
            doctorApplicationHandler.RemoveDoctor(Id);
        }
    }
}