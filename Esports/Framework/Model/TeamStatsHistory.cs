using System;
using Newtonsoft.Json;

namespace Framework.Model
{
    public class TeamStatsHistory
    {
        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("championIds")]
        public int[] ChampionIds { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("game")]
        public Guid Game { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("match")]
        public Guid Match { get; set; }

        [JsonProperty("opponent")]
        public int OpponentId { get; set; }

        [JsonProperty("team")]
        public int TeamId { get; set; }

        [JsonProperty("timestamp")]
        public double Timestamp { get; set; }

        [JsonProperty("win")]
        public bool Win { get; set; }
    }
}
