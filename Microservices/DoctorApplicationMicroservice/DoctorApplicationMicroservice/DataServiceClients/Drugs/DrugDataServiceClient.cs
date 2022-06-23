using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;

namespace DoctorApplicationMicroservice
{
    public class DrugDataServiceClient : IDrugDataServiceClient
    {
        public IHttpClientFactory clientFactory;

        private JsonSerializerOptions serializerOptions;
        private readonly AppConfig _appConfig;
        private string baseUrl = "";

        public DrugDataServiceClient(IHttpClientFactory clientFactory, IOptions<AppConfig> options)
        {
            this.clientFactory = clientFactory;
            serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _appConfig = options.Value;
            baseUrl = String.Format("{0}/Drugs", _appConfig.DrugDataBaseUrl);
        }

        public async Task<IEnumerable<DrugData>> GetAllDrugs()
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

            return await JsonSerializer.DeserializeAsync<IEnumerable<DrugData>>(responseStream, serializerOptions);
        }

        public async Task<DrugData> GetDrugById(string id)
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

            return await JsonSerializer.DeserializeAsync<DrugData>(responseStream, serializerOptions);
        }

        public async Task<IEnumerable<DrugData>> GetDrugsByType(string type)
        {
            string requesturl = baseUrl + "/GetByType?type=" + type;

            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, requesturl);

            httpRequest.Headers.Add("Accept", "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.SendAsync(httpRequest);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            if (responseStream.Length == 0)
            {
                return null;
            }

            return await JsonSerializer.DeserializeAsync<IEnumerable<DrugData>>(responseStream, serializerOptions);
        }
        public async void AddDrug(DrugData drugData)
        {
            string requesturl = baseUrl;

            var json = JsonSerializer.Serialize(drugData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = clientFactory.CreateClient();

            HttpResponseMessage response = await httpClient.PostAsync(requesturl, data);

            using var responseStream = await response.Content.ReadAsStreamAsync();
        }
        public async void RemoveDrug(string Id)
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
