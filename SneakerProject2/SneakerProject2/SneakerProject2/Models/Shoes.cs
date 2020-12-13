using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SneakerProject2.Models
{
    class Shoes
    {
        [JsonProperty(PropertyName = "success")]
        public string Succes { get; set; }

        [JsonProperty(PropertyName = "data")]
        public Results2 Data { get; set; }
    }

    public class Results2
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        [JsonProperty(PropertyName = "brand")]
        public string Brand { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "colorway")]
        public string Colorway { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "retailPrice")]
        public string RetailPrice { get; set; }

        [JsonProperty(PropertyName = "releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "releaseYear")]
        public string ReleaseYear { get; set; }

        [JsonProperty(PropertyName = "estimatedMarketValue")]
        public string EstimatedMarketValue { get; set; }

        [JsonProperty(PropertyName = "links")]
        public string Links { get; set; }

        [JsonProperty(PropertyName = "imgUrl")]
        public string ImgUrl { get; set; }

        [JsonProperty(PropertyName = "story")]
        public string Story { get; set; }

    }
}
