using Newtonsoft.Json;

namespace KazanExpressParser.Core.Services.ApiClient.Requests.GetCategories
{
    public class ApiCategoryResponse
    {
        [JsonProperty("payload")]
        public Payload Payload { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
    }
    public class Payload
    {
        [JsonProperty("category")]
        public ApiCategoryItem Category { get; set; }

        [JsonProperty("selectedCategory")]
        public object SelectedCategory { get; set; }
        
    }
}