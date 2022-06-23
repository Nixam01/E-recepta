using System;
using System.Collections.Generic;

namespace AppModels
{
    public partial class Model : IOperations
    {
        public void LoadDrugList()
        {
            this.LoadDrugsTask();
            /* AT
            Task.Run( ( ) => this.LoadNodesTask( ) );
            */
        }

        public void LoadDoctorList()
        {
            this.LoadDoctorsTask();
            /* AT
            Task.Run( ( ) => this.LoadNodesTask( ) );
            */
        }
        public void LoadPatientList()
        {
            this.LoadPatientsTask();
            /* AT
            Task.Run( ( ) => this.LoadNodesTask( ) );
            */
        }

        public void LoadPrescriptionList()
        {
            this.LoadPrescriptionsTask();
            /* AT
            Task.Run( ( ) => this.LoadNodesTask( ) );
            */
        }

        private void LoadDrugsTask()
        {
            IDoctor patientClient = DoctorClientFactory.GetPatientClient();

            try
            {
                List<DrugData> drugs = patientClient.GetAllDrugs();

                this.DrugList = drugs;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadDoctorsTask()
        {
            IDoctor patientClient = DoctorClientFactory.GetPatientClient();

            try
            {
                List<DoctorData> doctors = patientClient.GetAllDoctors();

                this.DoctorList = doctors;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadPatientsTask()
        {
            IDoctor patientClient = DoctorClientFactory.GetPatientClient();

            try
            {
                List<PatientData> patients = patientClient.GetAllPatients();

                this.PatientList = patients;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadPrescriptionsTask()
        {
            IDoctor patientClient = DoctorClientFactory.GetPatientClient();

            try
            {
                List<PrescriptionDataFull> prescriptions = patientClient.GetPrescriptionsByPesel(this.SearchText);

                this.PrescriptionList = prescriptions;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
