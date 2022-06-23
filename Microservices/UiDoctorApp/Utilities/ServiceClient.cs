using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppModels
{
    public class ServiceClient
    {
        private static HttpClient httpClient;

        private readonly string serviceHost;
        private readonly ushort servicePort;

        public ServiceClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceHost = serviceHost;
            this.servicePort = (ushort)servicePort;
        }

        public R CallWebService<R>(HttpMethod httpMethod, string webServiceUri)
        {
            Task<string> webServiceCall = this.CallWebService(httpMethod, webServiceUri);

            webServiceCall.Wait();

            string jsonResponseContent = webServiceCall.Result;

            R result = this.ConvertJson<R>(jsonResponseContent);

            return result;
        }

        public async Task<R> CallWebServiceAsync<R>(HttpMethod httpMethod, string webServiceUri)
        {
            string jsonResponseContent = await this.CallWebService(httpMethod, webServiceUri);

            R result = this.ConvertJson<R>(jsonResponseContent);

            return result;
        }

        public async Task<string> CallWebService(HttpMethod httpMethod, string callUri)
        {
            string httpUri = String.Format("http://{0}:{1}/{2}", this.serviceHost, this.servicePort, callUri);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, httpUri);

            httpRequestMessage.Headers.Add("Accept", "application/json");

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            httpClient = new HttpClient(clientHandler);

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            //httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        private T ConvertJson<T>(string json)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();

            jsonSerializerOptions.PropertyNameCaseInsensitive = true;

            return JsonSerializer.Deserialize<T>(json, jsonSerializerOptions);
        }
    }
}
