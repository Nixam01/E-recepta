using Microsoft.AspNetCore.Mvc;

namespace PrescriptionDataMicroservice
{
    [ApiController]
    [Route("Prescriptions")]
    public class PrescriptionController : ControllerBase, IPrescriptionService
    {
        private readonly ILogger<PrescriptionController> logger;
        private readonly IPrescription prescriptionLogic;

        public PrescriptionController(ILogger<PrescriptionController> logger)
        {
            this.logger = logger;
            this.prescriptionLogic = new PrescriptionLogic();
        }

        [HttpGet]
        [Route("GetAll")]
        public List<PrescriptionData> GetPrescriptions()
        {
            List<Prescription> prescriptions = this.prescriptionLogic.GetPrescriptions();
            return prescriptions.Select(prescription => prescription.ConvertToPrescriptionData()).ToList();
        }

        [HttpPost]
        [Route("")]
        public void AddPrescription(PrescriptionData prescriptionData)
        {
            this.prescriptionLogic.AddPrescription(DataConverter.ConvertPrescriptionDataToPrescription(prescriptionData));
        }

        [HttpGet]
        [Route("GetById")]
        public PrescriptionData GetPrescriptionById(string id)
        {
            Prescription prescription = this.prescriptionLogic.GetPrescriptionById(id);
            if (prescription == null)
            {
                return null;
            }
            return prescription.ConvertToPrescriptionData();
        }

        [HttpGet]
        [Route("GetByDoctorId")]
        public List<PrescriptionData> GetPrescriptionByDoctorID(string doctorID)
        {
            List<Prescription> prescriptions = this.prescriptionLogic.GetPrescriptionByDoctorID(doctorID);

            if (prescriptions.Count == 0)
            {
                return null;
            }

            return prescriptions.Select(prescription => prescription.ConvertToPrescriptionData()).ToList();
        }

        [HttpGet]
        [Route("GetByPatientId")]
        public List<PrescriptionData> GetPrescriptionByPatientID(string patientID)
        {
            List<Prescription> prescriptions = this.prescriptionLogic.GetPrescriptionByPatientID(patientID);

            if (prescriptions.Count == 0)
            {
                return null;
            }
            
            return prescriptions.Select(prescription => prescription.ConvertToPrescriptionData()).ToList();
        }
        [HttpPost]
        [Route("RemovePrescription")]
        public void RemovePrescription(string Id)
        {
            this.prescriptionLogic.RemovePrescription(Id);
        }
    }
}