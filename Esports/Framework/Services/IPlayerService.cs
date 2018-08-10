using Framework.Model;
using System.Collections.Generic;

namespace Framework.Services
{
    public interface IPlayerService
    {
        List<PlayerStats> GetAllPlayerStats();

        PlayerStats GetPlayerStatsById(int id);

        PlayerStats GetPlayerStatsByName(string name);
    }
}
