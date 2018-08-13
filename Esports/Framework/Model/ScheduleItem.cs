using System;
using Newtonsoft.Json;

namespace Framework.Model
{
    public class ScheduleItem
    {
        [JsonProperty("bracket")]
        public Guid Bracket { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("league")]
        public int League { get; set; }

        [JsonProperty("match")]
        public Guid Match { get; set; }

        [JsonProperty("scheduledTime")]
        public DateTime ScheduledTime { get; set; }

        [JsonProperty("tags")]
        public dynamic Tags { get; set; }

        [JsonProperty("tournament")]
        public Guid Tournament { get; set; }
    }
}
