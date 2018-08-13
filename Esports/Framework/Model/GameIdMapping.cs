using System;
using Newtonsoft.Json;

namespace Framework.Model
{
    public class GameIdMapping
    {
        [JsonProperty("gameHash")]
        public string GameHash { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
