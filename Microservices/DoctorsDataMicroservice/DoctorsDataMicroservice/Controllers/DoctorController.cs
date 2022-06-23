using Microsoft.AspNetCore.Mvc;

namespace DoctorsDataMicroservice
{
    [ApiController]
    [Route("Doctors")]
    public class DoctorController : ControllerBase, IDoctorService
    {
        private readonly ILogger<DoctorController> logger;
        private readonly IDoctor doctorLogic;

        public DoctorController(ILogger<DoctorController> logger)
        {
            this.logger = logger;
            this.doctorLogic = new DoctorLogic();
        }

        [HttpGet]
        [Route("GetAll")]
        public List<DoctorData> GetDoctors()
        {
            List<Doctor> doctors = this.doctorLogic.GetDoctors();
            return doctors.Select(doctor => doctor.ConvertToDoctorData()).ToList();
        }

        [HttpPost]
        [Route("")]
        public void AddDoctor(DoctorData doctorData)
        {
            this.doctorLogic.AddDoctor(DataConverter.ConvertDoctorDataToDoctor(doctorData));
        }

        [HttpGet]
        [Route("GetById")]
        public DoctorData GetDoctorById(string id)
        {
            Doctor doctor = this.doctorLogic.GetDoctorById(id);
            if (doctor == null)
            {
                //var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                //{
                //    Content = new StringContent(string.Format("No doctor with ID = {0}", id)),
                //    ReasonPhrase = "Doctor with ID Not Found"
                //};
                //throw new System.Web.Http.HttpResponseException(resp);
                return null;
            }
            return doctor.ConvertToDoctorData();
        }

        [HttpGet]
        [Route("GetBySpecialisation")]
        public List<DoctorData> GetDoctorsBySpecialisation(string specialisation)
        {
            bool enumIsValid = Enum.TryParse(specialisation, true, out DoctorSpecialisation doctorSpecialisation);
            if (!enumIsValid)
            {
                return null;
            };

            List<Doctor> doctors = this.doctorLogic.GetDoctorsBySpecialisation(doctorSpecialisation);
            return doctors.Select(doctor => doctor.ConvertToDoctorData()).ToList();
        }
        [HttpPost]
        [Route("RemoveDoctor")]
        public void RemoveDoctor(string email)
        {
            this.doctorLogic.RemoveDoctor(email);
        }
    }
}