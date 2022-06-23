using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace AppModels
{
    public class DoctorClient : IDoctor
    {
        private readonly ServiceClient serviceClient;

        public DoctorClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public List<DrugData> GetAllDrugs()
        {
            string callUri = "Drugs/getAll";

            List<DrugData> drugs = this.serviceClient.CallWebService<DrugData[]>(HttpMethod.Get, callUri).ToList();

            return drugs;
        }

        public List<DoctorData> GetAllDoctors()
        {
            string callUri = "Doctors/GetAll";

            List<DoctorData> doctors = this.serviceClient.CallWebService<DoctorData[]>(HttpMethod.Get, callUri).ToList();

            return doctors;
        }

        public List<PatientData> GetAllPatients()
        {
            string callUri = "Patients/GetAll";

            List<PatientData> patients = this.serviceClient.CallWebService<PatientData[]>(HttpMethod.Get, callUri).ToList();

            return patients;
        }

        public DoctorData GetDoctorById(string id)
        {
            string callUri = String.Format("Doctors/GetById?id={0}", id);

            DoctorData doctor = this.serviceClient.CallWebService<DoctorData>(HttpMethod.Get, callUri);

            return doctor;
        }

        public List<PrescriptionDataFull> GetPrescriptionsByPesel(string pesel)
        {
            string callUri = String.Format("Prescriptions/GetAll", pesel); ;

            List<PrescriptionDataFull> prescriptions = this.serviceClient.CallWebService<PrescriptionDataFull[]>(HttpMethod.Get, callUri).ToList();

            return prescriptions;
        }
    }
}
