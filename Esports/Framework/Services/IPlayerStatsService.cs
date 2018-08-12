using Framework.Model;
using System.Collections.Generic;

namespace Framework.Services
{
    public interface IPlayerStatsService
    {
        List<PlayerStats> GetAllPlayerStats();

        PlayerStats GetPlayerStatsById(int id);

        PlayerStats GetPlayerStatsByName(string name);
    }
}
