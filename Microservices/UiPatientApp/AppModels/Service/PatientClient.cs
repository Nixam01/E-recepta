using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace AppModels
{
    public class PatientClient : IPatient
    {
        private readonly ServiceClient serviceClient;

        public PatientClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public List<DrugData> GetAllDrugs()
        {
            string callUri = "Drugs/getAllDrugs";

            List<DrugData> drugs = this.serviceClient.CallWebService<DrugData[]>(HttpMethod.Get, callUri).ToList();

            return drugs;
        }

        public List<DoctorData> GetAllDoctors()
        {
            string callUri = "Doctors/GetAll";

            List<DoctorData> doctors = this.serviceClient.CallWebService<DoctorData[]>(HttpMethod.Get, callUri).ToList();

            return doctors;
        }

        public DoctorData GetDoctorById(string id)
        {
            string callUri = String.Format("Doctors/GetById?id={0}", id);

            DoctorData doctor = this.serviceClient.CallWebService<DoctorData>(HttpMethod.Get, callUri);

            return doctor;
        }

        public List<PrescriptionDataFull> GetPrescriptionsByPesel(string pesel)
        {
            string callUri = String.Format("Prescriptions/GetMyPrescriptions?pesel={0}", pesel); ;

            List<PrescriptionDataFull> prescriptions = this.serviceClient.CallWebService<PrescriptionDataFull[]>(HttpMethod.Get, callUri).ToList();

            return prescriptions;
        }
    }
}
