using Newtonsoft.Json;
using System.Collections.Generic;

namespace doctolibsniper.Models
{
    public class SearchResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_directory")]
        public bool IsDirectory { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("cloudinary_public_id")]
        public string CloudinaryPublicId { get; set; }

        [JsonProperty("profile_id")]
        public int ProfileId { get; set; }

        [JsonProperty("exact_match")]
        public object ExactMatch { get; set; }

        [JsonProperty("priority_speciality")]
        public bool PrioritySpeciality { get; set; }

        [JsonProperty("first_name")]
        public object FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("name_with_title")]
        public string NameWithTitle { get; set; }

        [JsonProperty("speciality")]
        public object Speciality { get; set; }

        [JsonProperty("organization_status")]
        public string OrganizationStatus { get; set; }

        [JsonProperty("top_specialities")]
        public List<string> TopSpecialities { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("place_id")]
        public object PlaceId { get; set; }

        [JsonProperty("telehealth")]
        public bool Telehealth { get; set; }

        [JsonProperty("visit_motive_id")]
        public int VisitMotiveId { get; set; }

        [JsonProperty("visit_motive_name")]
        public string VisitMotiveName { get; set; }

        [JsonProperty("agenda_ids")]
        public List<int> AgendaIds { get; set; }

        [JsonProperty("landline_number")]
        public string LandlineNumber { get; set; }

        [JsonProperty("booking_temporary_disabled")]
        public bool BookingTemporaryDisabled { get; set; }

        [JsonProperty("resetVisitMotive")]
        public bool ResetVisitMotive { get; set; }

        [JsonProperty("toFinalizeStep")]
        public bool ToFinalizeStep { get; set; }

        [JsonProperty("toFinalizeStepWithoutState")]
        public bool ToFinalizeStepWithoutState { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
