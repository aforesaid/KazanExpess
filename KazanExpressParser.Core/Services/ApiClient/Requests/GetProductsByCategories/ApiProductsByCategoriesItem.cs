using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KazanExpressParser.Core.Services.ApiClient.Requests.GetProductsByCategories
{
    public class ApiProductsByCategoriesItem
    {
        [JsonProperty("productId")]
        public long ProductId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("sellPrice")]
        public long SellPrice { get; set; }

        [JsonProperty("fullPrice")]
        public long FullPrice { get; set; }

        [JsonProperty("compressedImage")]
        public Uri CompressedImage { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("ordersQuantity")]
        public long OrdersQuantity { get; set; }

        [JsonProperty("rOrdersQuantity")]
        public long ROrdersQuantity { get; set; }

        [JsonProperty("isFavorite")]
        public object IsFavorite { get; set; }

        [JsonProperty("isAdultCategory")]
        public bool IsAdultCategory { get; set; }

        [JsonProperty("charityCommission")]
        public long CharityCommission { get; set; }

        [JsonProperty("isEco")]
        public bool IsEco { get; set; }

        [JsonProperty("hasVerticalPhoto")]
        public bool HasVerticalPhoto { get; set; }

        [JsonProperty("offer")]
        public ApiProductsByCategoriesOffer Offer { get; set; }

        [JsonProperty("badges")]
        public List<ApiProductsByCategoriesBadge> Badges { get; set; }

        [JsonProperty("characteristicValueIds")]
        public object CharacteristicValueIds { get; set; }
    }
}