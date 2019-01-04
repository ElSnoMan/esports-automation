using System;
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

        string _baseUrl => "https://api.lolesports.com/api/v2";
        string _playerStatsEndpoint => _baseUrl + "/tournamentPlayerStats";

        public List<PlayerStats> GetAllPlayerStats(string groupName, string tournamentId)
        {
            var client = new RestClient(_playerStatsEndpoint);
            var request = new RestRequest($"?groupName={groupName}&tournamentId={new Guid(tournamentId)}", Method.GET);
            var response = client.Execute(request);

            dynamic json = JsonConvert.DeserializeObject(response.Content);
            return json["stats"].ToObject<List<PlayerStats>>();
        }

        public PlayerStats GetPlayerStatsById(string groupName, string tournamentId, int id)
        {
            return GetAllPlayerStats(groupName, tournamentId).FirstOrDefault(p => p.Id == id);
        }

        public PlayerStats GetPlayerStatsByName(string groupName, string tournamentId, string name)
        {
            return GetAllPlayerStats(groupName, tournamentId).FirstOrDefault(p => p.Name == name);
        }
    }
}