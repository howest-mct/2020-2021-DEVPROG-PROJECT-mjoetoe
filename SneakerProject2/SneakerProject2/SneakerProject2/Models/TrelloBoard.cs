using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace SneakerProject2.Models
{
    class TrelloBoard
    {
        [JsonProperty(PropertyName = "id")] //name in json
        public string BoardId { get; set; } //name of property we want to use

        public string Name { get; set; }

        [JsonProperty(PropertyName = "starred")]
        public bool IsFavorite { get; set; }

        public string ColorHex { get; set; }
        [JsonExtensionData]
        private Dictionary<string, JToken> _extraJsonData = new Dictionary<string, JToken>();

        [OnDeserialized]
        private void ProcessExtraJsonData(StreamingContext context)
        {
            JToken prefsData = (JToken)_extraJsonData["prefs"];
            ColorHex = (string)prefsData.SelectToken("backgroundColor");
        }
    }
}
