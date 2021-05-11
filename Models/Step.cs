using Newtonsoft.Json;
using System;

namespace doctolibsniper.Models
{
    public class Step
    {
        [JsonProperty("agenda_id")]
        public int AgendaId { get; set; }

        [JsonProperty("practitioner_agenda_id")]
        public object PractitionerAgendaId { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("visit_motive_id")]
        public int VisitMotiveId { get; set; }
    }
}
