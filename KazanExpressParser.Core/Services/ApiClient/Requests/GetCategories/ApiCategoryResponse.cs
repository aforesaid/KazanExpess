using Newtonsoft.Json;

namespace KazanExpressParser.Core.Services.ApiClient.Requests.GetCategories
{
    public class ApiCategoryResponse
    {
        [JsonProperty("payload")]
        public CategoryPayload CategoryPayload { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
    }
    public class CategoryPayload
    {
        [JsonProperty("category")]
        public ApiCategoryItem Category { get; set; }

        [JsonProperty("selectedCategory")]
        public object SelectedCategory { get; set; }
        
    }
}