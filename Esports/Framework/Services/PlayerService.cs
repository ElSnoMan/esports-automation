using System.Collections.Generic;
using System.Linq;
using Framework.Model;
using Newtonsoft.Json;
using RestSharp;

namespace Framework.Services
{
    public class PlayerService : IPlayerStatsService
    {
        // player stats parameters:
                // groupName(string)
                // tournamentId(Guid)
        // examples:
                // groupName=regular_season
                // tournamentId=8531db79-ade3-4294-ae4a-ef639967c393

        public PlayerService(string groupName, string tournamentId)
        {
            GroupName = groupName;
            TournamentId = tournamentId;
        }

        //TODO: move connection string to config json
        string _baseUrl => "https://api.lolesports.com/api/v2";
        string _playerStatsEndpoint => _baseUrl + "/tournamentPlayerStats";

        public string GroupName { get; private set; }
        public string TournamentId { get; private set; }

        public List<PlayerStats> GetAllPlayerStats()
        {
            var client = new RestClient(_playerStatsEndpoint);
            var request = new RestRequest($"?groupName={GroupName}&tournamentId={TournamentId}", Method.GET);
            var response = client.Execute(request);

            dynamic json = JsonConvert.DeserializeObject(response.Content);
            return json["stats"].ToObject<List<PlayerStats>>();
        }

        public PlayerStats GetPlayerStatsById(int id)
        {
            return GetAllPlayerStats().FirstOrDefault(p => p.Id == id);
        }

        public PlayerStats GetPlayerStatsByName(string name)
        {
            return GetAllPlayerStats().FirstOrDefault(p => p.Name == name);
        }
    }
}