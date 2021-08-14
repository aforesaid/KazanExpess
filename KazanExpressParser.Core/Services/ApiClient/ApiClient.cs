using System;
using System.Net.Http;
using System.Threading.Tasks;
using KazanExpressParser.Core.Services.ApiClient.Requests.GetCategories;

namespace KazanExpressParser.Core.Services.ApiClient
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiClientEndpoints.BaseAddress)
            };
        }
        public Task<ApiCategoryItem> GetCategories()
        {
            
        }
        
    }
}