using Newtonsoft.Json;

namespace KazanExpressParser.Core.Services.ApiClient.Requests.GetProductsByCategories
{
    public class ApiProductsByCategoriesOffer
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("text")]
        public object Text { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}