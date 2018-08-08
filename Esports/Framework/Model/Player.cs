using Newtonsoft.Json;

namespace Framework.Model
{
    public class Player
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("summoner")]
        public string Summoner { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("stats")]
        public PlayerStats Stats { get; set; }
    }
}