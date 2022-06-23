namespace AppModels
{
    public static class PatientClientFactory
    {
        public static IPatient GetPatientClient()
        {
#if DEBUG
            const string serviceHost = "127.0.0.1";
            const int servicePort = 5243;
            return new PatientClient(serviceHost, servicePort);
#else
            const string serviceHost = "patients-application-microservice";
            const int servicePort = 80;
            return new PatientClient(serviceHost, servicePort);
#endif

        }
    }
}
