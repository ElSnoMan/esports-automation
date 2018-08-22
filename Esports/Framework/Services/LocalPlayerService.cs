using System.Collections.Generic;
using System.IO;
using System.Linq;
using Framework.Model;
using Newtonsoft.Json;

namespace Framework.Services
{
    public class LocalPlayerService
    {
        public LocalPlayerService()
        {
            _playerStats = DeserializeLocalJson();
        }

        readonly List<PlayerStats> _playerStats;

        public List<PlayerStats> GetAllPlayerStats()
        {
            return _playerStats;
        }

        public PlayerStats GetPlayerStatsById(int id)
        {
            return _playerStats.FirstOrDefault(p => p.Id == id);
        }

        public PlayerStats GetPlayerStatsByName(string name)
        {
            return _playerStats.FirstOrDefault(p => p.Name == name);
        }

        private List<PlayerStats> DeserializeLocalJson()
        {
            dynamic json = JsonConvert.DeserializeObject(
                File.ReadAllText($"{Directory.GetCurrentDirectory()}/Framework/Data/tournamentPlayerStats.json")
            );

            return json["stats"].ToObject<List<PlayerStats>>();
        }
    }
}
