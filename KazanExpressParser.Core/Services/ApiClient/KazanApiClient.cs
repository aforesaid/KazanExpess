using System;
using System.Net.Http;
using System.Threading.Tasks;
using KazanExpressParser.Core.Services.ApiClient.Base;
using KazanExpressParser.Core.Services.ApiClient.Requests.GetCategories;

namespace KazanExpressParser.Core.Services.ApiClient
{
    public class KazanApiClient : ApiClientBase, IKazanApiClient
    {
        public KazanApiClient()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiClientEndpoints.BaseAddress)
            };
        }
        public async Task<ApiCategoryItem> GetCategories()
        {
            var url = ApiClientEndpoints.GetCategories;
            var response = await Get<ApiCategoryResponse>(url);

            return response.Payload.Category;
        }
        
    }
}