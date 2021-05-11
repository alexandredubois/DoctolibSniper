using Newtonsoft.Json;
using System.Collections.Generic;

namespace doctolibsniper.Models
{
    public class DoctolibReturnObject
    {
        [JsonProperty("availabilities")]
        public List<Availability> Availabilities { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("search_result")]
        public SearchResult SearchResult { get; set; }
    }
}
