using Framework.Model;
using System;
using System.Collections.Generic;

namespace Framework.Services
{
    public interface IPlayerStatsService
    {
        List<PlayerStats> GetAllPlayerStats(string groupName, string tournamentId);

        PlayerStats GetPlayerStatsById(string groupName, string tournamentId, int id);

        PlayerStats GetPlayerStatsByName(string groupName, string tournamentId, string name);
    }
}
