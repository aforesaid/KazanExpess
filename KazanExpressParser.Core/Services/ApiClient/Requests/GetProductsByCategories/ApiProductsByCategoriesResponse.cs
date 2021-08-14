using System.Collections.Generic;
using Newtonsoft.Json;

namespace KazanExpressParser.Core.Services.ApiClient.Requests.GetProductsByCategories
{
    public class ApiProductsByCategoriesResponse
    {
        [JsonProperty("payload")]
        public GetProductsByCategoriesPayload CategoryPayload { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
    }
    public class GetProductsByCategoriesPayload
    {
        [JsonProperty("products")]
        public List<ApiProductsByCategoriesItem> Products { get; set; }

        [JsonProperty("adultContent")]
        public bool AdultContent { get; set; }
    }
}