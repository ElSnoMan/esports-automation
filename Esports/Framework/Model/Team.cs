using System;
using Newtonsoft.Json;

namespace Framework.Model
{
    public class Team
    {
        [JsonProperty("acronym")]
        public string Acronym { get; set; }

        [JsonProperty("altLogoUrl")]
        public string AltLogoUrl { get; set; }

        [JsonProperty("bios")]
        public dynamic Bios { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("foreignIds")]
        public dynamic ForeignIds { get; set; }

        [JsonProperty("guid")]
        public Guid Guid { get; set; }

        [JsonProperty("homeLeague")]
        public string HomeLeague { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("logoUrl")]
        public string LogoUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("players")]
        public int[] PlayerIds { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("starters")]
        public int[] Starters { get; set; }

        [JsonProperty("subs")]
        public int[] Subs { get; set; }

        [JsonProperty("teamPhotoUrl")]
        public string TeamPhotoUrl { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
