using System.Collections.Generic;
using Newtonsoft.Json;

namespace KazanExpressParser.Core.Services.ApiClient.Requests.GetCategories
{
    public class ApiCategoryItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("productAmount")]
        public long ProductAmount { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("eco")]
        public bool Eco { get; set; }

        [JsonProperty("iconLink")]
        public object IconLink { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("seoMetaTag")]
        public object SeoMetaTag { get; set; }

        [JsonProperty("seoHeader")]
        public object SeoHeader { get; set; }

        [JsonProperty("children")]
        public List<ApiCategoryItem> Children { get; set; }

        [JsonProperty("path")]
        public List<long> Path { get; set; }
    }
}