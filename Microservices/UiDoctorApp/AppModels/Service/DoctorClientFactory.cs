namespace AppModels
{
    public static class DoctorClientFactory
    {
        public static IDoctor GetPatientClient()
        {
#if DEBUG
            const string serviceHost = "127.0.0.1";
            const int servicePort = 5204;
            return new DoctorClient(serviceHost, servicePort);
#else
            const string serviceHost = "doctors-application-microservice";
            const int servicePort = 80;
            return new DoctorClient(serviceHost, servicePort);
#endif

        }
    }
}
