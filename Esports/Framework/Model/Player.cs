using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Framework.Model
{
    public class Player
    {
        [JsonProperty("bios")]
        public dynamic Bios { get; set; }

        [JsonProperty("birthdate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("champions")]
        public List<object> Champions { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("foreignIds")]
        public dynamic ForeignIds { get; set; }

        [JsonProperty("hometown")]
        public string HomeTown { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photoUrl")]
        public string PhotoUrl { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("roleSlug")]
        public string RoleSlug { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("socialNetworks")]
        public dynamic SocialNetworks { get; set; }

        [JsonProperty("teamRosterStat")]
        public string TeamRosterStat { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
