using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using KazanExpressParser.Core.Services.ApiClient.Base;
using KazanExpressParser.Core.Services.ApiClient.Requests.GetCategories;
using KazanExpressParser.Core.Services.ApiClient.Requests.GetProductsByCategories;

namespace KazanExpressParser.Core.Services.ApiClient
{
    public class KazanApiClient : ApiClientBase, IKazanApiClient, IDisposable
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

            return response.CategoryPayload.Category;
        }

        public async Task<ApiProductsByCategoriesItem[]> GetProductsByCategoryId(long categoryId, int maxCountPage = 100)
        {
            var page = 0;
            const int sizeCount = 100;
            var result = new List<ApiProductsByCategoriesItem>();
            
            ApiProductsByCategoriesResponse response;
            do
            {
                var url = ApiClientEndpoints.GetProductsByCategories(categoryId, page: page, sizeCount: sizeCount);
                response = await Get<ApiProductsByCategoriesResponse>(url);
                result.AddRange(response.CategoryPayload.Products);
                page++;
            } while (response.CategoryPayload.Products.Count == sizeCount && page < maxCountPage);

            return result.ToArray();
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}