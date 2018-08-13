using Newtonsoft.Json;

namespace Framework.Model
{
    public class TeamRosterStats
    {
        [JsonProperty("averageAssists")]
        public double AvgAssists { get; set; }

        [JsonProperty("averageDeaths")]
        public double AvgDeaths { get; set; }

        [JsonProperty("averageKillParticipation")]
        public double AvgKillParticipation { get; set; }

        [JsonProperty("averageKills")]
        public double AvgKills { get; set; }

        [JsonProperty("championIds")]
        public int[] ChampionIds { get; set; }

        [JsonProperty("gamesPlayed")]
        public int GamesPlayed { get; set; }

        [JsonProperty("playerId")]
        public string PlayerId { get; set; }

        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
    }
}
