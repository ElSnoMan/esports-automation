using Newtonsoft.Json;

namespace Framework.Model
{
    public class PlayerStats
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("playerSlug")]
        public string PlayerSlug { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("gamesPlayed")]
        public int GamesPlayed { get; set; }

        [JsonProperty("kda")]
        public double KDA { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("killParticipation")]
        public double KillParticipation { get; set; }

        [JsonProperty("csPerMin")]
        public double CsPerMin { get; set; }

        [JsonProperty("cs")]
        public int Cs { get; set; }

        [JsonProperty("minutesPlayed")]
        public int MinutesPlayed { get; set; }

        [JsonProperty("teamSlug")]
        public string TeamSlug { get; set; }
    }
}