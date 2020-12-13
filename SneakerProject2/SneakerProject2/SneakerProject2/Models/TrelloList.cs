using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SneakerProject2.Models
{
    class TrelloList
    {
        [JsonProperty(PropertyName = "id")] //name in json
        public string ListId { get; set; } //name of property we want to use
        public string Name { get; set; }
    }
}
