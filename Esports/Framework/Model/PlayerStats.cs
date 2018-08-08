using Newtonsoft.Json;

namespace Framework.Model
{
    public class PlayerStats
    {
        [JsonProperty("split")]
        public string Split { get; set; }

        [JsonProperty("stage")]
        public string Stage { get; set; }

        [JsonProperty("kda")]
        public double KDA { get; set; }

        [JsonProperty("csPerMin")]
        public double CsPerMin { get; set; }

        [JsonProperty("killParticipation")]
        public double KillParticipation { get; set; }

        [JsonProperty("totalKills")]
        public int TotalKills { get; set; }

        [JsonProperty("totalDeaths")]
        public int TotalDeaths { get; set; }

        [JsonProperty("totalAssists")]
        public int TotalAssists { get; set; }

        [JsonProperty("totalCs")]
        public int TotalCs { get; set; }

        [JsonProperty("minutesPlayed")]
        public int MinutesPlayed { get; set; }

        [JsonProperty("gamesPlayed")]
        public int GamesPlayed { get; set; }
    }
}