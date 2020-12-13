using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SneakerProject2.Models
{
    class TrelloCard
    {
        [JsonProperty(PropertyName = "id")] //name in json
        public string CardId { get; set; } //name of property we want to use


        [JsonProperty(PropertyName = "desc")] //name in json
        public string CardDesc { get; set; } //name of property we want to use

        public string name { get; set; }

        [JsonProperty(PropertyName = "closed")]
        public bool IsClosed { get; set; }

        [JsonProperty(PropertyName = "badges")]
        public CardInformation CardInfo { get; set; }


    }

    public class CardInformation
    {

        [JsonProperty(PropertyName = "comments")]
        public int NumComments { get; set; }

        [JsonProperty(PropertyName = "attachments")]
        public int NumAttachments { get; set; }
    }
}
