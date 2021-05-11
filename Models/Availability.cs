using Newtonsoft.Json;
using System.Collections.Generic;

namespace doctolibsniper.Models
{
    public class Availability
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("slots")]
        public List<Slot> Slots { get; set; }

        [JsonProperty("substitution")]
        public object Substitution { get; set; }
    }
}
