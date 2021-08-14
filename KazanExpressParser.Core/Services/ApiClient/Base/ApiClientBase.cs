using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KazanExpressParser.Core.Services.ApiClient.Base
{
    public class ApiClientBase
    {
        protected HttpClient HttpClient;

        protected async Task<TResponse> Post<TRequest, TResponse>(string url, TRequest requestModel)
        {
            var requestJson = ToJson(requestModel);
            var request = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync(url, request);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = ToModel<TResponse>(responseString);

            return result;
        }

        protected async Task<T> Get<T>(string url)
        {
            var response = await HttpClient.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();
            
            var result = ToModel<T>(responseString);
            return result;
        }

        private static string ToJson<TRequest>(TRequest request)
        {
            var jsonSerializer = new JsonSerializerSettings
            {
            };
            var stringContent = JsonConvert.SerializeObject(request, jsonSerializer);
            return stringContent;
        }

        private static T ToModel<T>(string stringContent)
        {
            var jsonSerializer = new JsonSerializerSettings
            {
            };
            var model = JsonConvert.DeserializeObject<T>(stringContent, jsonSerializer);
            return model;
        }
    }
}