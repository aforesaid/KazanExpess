using Newtonsoft.Json;

namespace KazanExpressParser.Core.Services.ApiClient.Requests.GetProductsByCategories
{
    public class ApiProductsByCategoriesBadge
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; }

        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("link")]
        public object Link { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}