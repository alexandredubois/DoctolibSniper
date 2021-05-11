using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace doctolibsniper.Models
{
    public class Slot
    {
        [JsonProperty("agenda_id")]
        public int AgendaId { get; set; }

        [JsonProperty("practitioner_agenda_id")]
        public object PractitionerAgendaId { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("steps")]
        public List<Step> Steps { get; set; }
    }
}
