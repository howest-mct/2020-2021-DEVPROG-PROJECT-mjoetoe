using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SneakerProject2.Models
{
    public class Brands
    {
        [JsonProperty(PropertyName = "results")]
        public List < string > Result { get; set; }
    }

}
