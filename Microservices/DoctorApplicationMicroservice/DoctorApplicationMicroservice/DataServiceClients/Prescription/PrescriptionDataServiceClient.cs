using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace DoctorApplicationMicroservice
{
    public class PrescriptionDataServiceClient : IPrescriptionDataServiceClient
    {
        public IHttpClientFactory clientFactory;

        private JsonSerializerOptions serializerOptions;
        private readonly AppConfig _appConfig;
        private string baseUrl = "";

        public PrescriptionDataServiceClient(IHttpClientFactory clientFactory, IOptions<AppConfig> options)
        {
            this.clientFactory = clientFactory;
            serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _appConfig = options.Value;
            baseUrl = String.Format("{0}/Prescriptions", _appConfig.PrescriptionDataBaseUrl);
        }

        public async Task<IEnumerable<PrescriptionData>> GetAllPrescriptions()
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

            return await JsonSerializer.DeserializeAsync<IEnumerable<PrescriptionData>>(responseStream, serializerOptions);
        }

        public async Task<PrescriptionData> GetPrescriptionById(string id)
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

            return await JsonSerializer.DeserializeAsync<PrescriptionData>(responseStream, serializerOptions);
        }

        public async Task<IEnumerable<PrescriptionData>> GetPrescriptionsByDoctorId(string id)
        {
            string requesturl = baseUrl + "/GetByDoctorId?doctorID=" + id;

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, requesturl);

            httpRequest.Headers.Add("Accept", "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.SendAsync(httpRequest);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            if (responseStream.Length == 0)
            {
                return null;
            }

            return await JsonSerializer.DeserializeAsync<IEnumerable<PrescriptionData>>(responseStream, serializerOptions);
        }

        public async Task<IEnumerable<PrescriptionData>> GetPrescriptionsByPatientId(string id)
        {
            string requesturl = baseUrl + "/GetByPatientId?patientID=" + id;

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, requesturl);

            httpRequest.Headers.Add("Accept", "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.SendAsync(httpRequest);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            if (responseStream.Length == 0)
            {
                return null;
            }

            return await JsonSerializer.DeserializeAsync<IEnumerable<PrescriptionData>>(responseStream, serializerOptions);
        }

        public async void AddPrescription(PrescriptionData prescriptionData)
        {
            string requesturl = baseUrl;

            var json = JsonSerializer.Serialize(prescriptionData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.PostAsync(requesturl, data);

            using var responseStream = await response.Content.ReadAsStreamAsync();
        }
        public async void RemovePrescription(string Id)
        {
            string requesturl = baseUrl;

            var json = JsonSerializer.Serialize(Id);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.PostAsync(requesturl, data);

            using var responseStream = await response.Content.ReadAsStreamAsync();
        }
    }
}
