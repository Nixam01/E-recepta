using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;

namespace DoctorApplicationMicroservice
{
    public class DoctorDataServiceClient : IDoctorDataServiceClient
    {
        public IHttpClientFactory clientFactory;

        private JsonSerializerOptions serializerOptions;
        private readonly AppConfig _appConfig;
        private string baseUrl = "";

        public DoctorDataServiceClient(IHttpClientFactory clientFactory, IOptions<AppConfig> options)
        {
            this.clientFactory = clientFactory;
            serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _appConfig = options.Value;
            baseUrl = String.Format("{0}/Doctors", _appConfig.DoctorDataBaseUrl);
        }

        public async Task<IEnumerable<DoctorData>> GetAllDoctors()
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

            return await JsonSerializer.DeserializeAsync<IEnumerable<DoctorData>>(responseStream, serializerOptions);
        }

        public async Task<DoctorData> GetDoctorById(string id)
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

            return await JsonSerializer.DeserializeAsync<DoctorData>(responseStream, serializerOptions);
        }

        public async Task<IEnumerable<DoctorData>> GetDoctorsBySpecialisation(string specialisation)
        {
            string requesturl = baseUrl + "/GetBySpecialisation?specialisation=" + specialisation;

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, requesturl);

            httpRequest.Headers.Add("Accept", "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.SendAsync(httpRequest);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            if (responseStream.Length == 0)
            {
                return null;
            }

            return await JsonSerializer.DeserializeAsync<IEnumerable<DoctorData>>(responseStream, serializerOptions);
        }
        public async void AddDoctor(DoctorData doctorData)
        {
            string requesturl = baseUrl;

            var json = JsonSerializer.Serialize(doctorData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.PostAsync(requesturl, data);

            using var responseStream = await response.Content.ReadAsStreamAsync();
        }
        public async void RemoveDoctor(string Id)
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
