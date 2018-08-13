using Newtonsoft.Json;

namespace Framework.Model
{
    public class TeamStatsSummary
    {
        [JsonProperty("averageDamageByPosition")]
        public dynamic AvgDmgByPosition { get; set; }

        [JsonProperty("averageWinLength")]
        public int AvgWinLength { get; set; }

        [JsonProperty("averageWinLengthRank")]
        public int AvgWinLengthRank { get; set; }

        [JsonProperty("firstDragonKillRatio")]
        public double FirstDragonKillRatio { get; set; }

        [JsonProperty("firstDragonKillRatioRank")]
        public int FirstDragonKillRatioRank { get; set; }

        [JsonProperty("firstTowerRatio")]
        public double FirstTowerRatio { get; set; }

        [JsonProperty("firstTowerRatioRank")]
        public int FirstTowerRatioRank { get; set; }

        [JsonProperty("kdaRatio")]
        public double KdaRatio { get; set; }

        [JsonProperty("kdaRatioRank")]
        public int KdaRatioRank { get; set; }

        [JsonProperty("teamId")]
        public string TeamId { get; set; }
    }
}
