using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;

namespace DoctorApplicationMicroservice
{
    public class PatientDataServiceClient : IPatientDataServiceClient
    {
        public IHttpClientFactory clientFactory;

        private JsonSerializerOptions serializerOptions;
        private readonly AppConfig _appConfig;
        private string baseUrl = "";

        public PatientDataServiceClient(IHttpClientFactory clientFactory, IOptions<AppConfig> options)
        {
            this.clientFactory = clientFactory;
            serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _appConfig = options.Value;
            baseUrl = String.Format("{0}/Patients", _appConfig.PatientDataBaseUrl);
        }

        public async Task<IEnumerable<PatientData>> GetAllPatients()
        {
            string requesturl = baseUrl + "/GetAll";

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, requesturl);

            httpRequest.Headers.Add("Accept", "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.SendAsync(httpRequest);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            if (responseStream.Length == 0)
            {
                return null;
            }

            return await JsonSerializer.DeserializeAsync<IEnumerable<PatientData>>(responseStream, serializerOptions);
        }

        public async Task<PatientData> GetPatientById(string id)
        {
            string requesturl = baseUrl + "/GetById?id=" + id;

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, requesturl);

            httpRequest.Headers.Add("Accept", "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.SendAsync(httpRequest);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            if (responseStream.Length == 0)
            {
                return null;
            }

            return await JsonSerializer.DeserializeAsync<PatientData>(responseStream, serializerOptions);
        }

        public async Task<PatientData> GetPatientByPesel(string pesel)
        {
            string requesturl = baseUrl + "/GetByPesel?pesel=" + pesel;

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, requesturl);

            httpRequest.Headers.Add("Accept", "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.SendAsync(httpRequest);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            if (responseStream.Length == 0)
            {
                return null;
            }

            return await JsonSerializer.DeserializeAsync<PatientData>(responseStream, serializerOptions);
        }
        public async void AddPatient(PatientData patientData)
        {
            string requesturl = baseUrl;

            var json = JsonSerializer.Serialize(patientData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.PostAsync(requesturl, data);

            using var responseStream = await response.Content.ReadAsStreamAsync();
        }
        public async void RemovePatient(string id)
        {
            string requesturl = baseUrl;

            var json = JsonSerializer.Serialize(id);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.PostAsync(requesturl, data);

            using var responseStream = await response.Content.ReadAsStreamAsync();
        }
    }
}
