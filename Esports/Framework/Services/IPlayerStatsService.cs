using Framework.Model;
using System;
using System.Collections.Generic;

namespace Framework.Services
{
    public interface IPlayerStatsService
    {
        List<PlayerStats> GetAllPlayerStats(string groupName, Guid tournamentId);

        PlayerStats GetPlayerStatsById(string groupName, Guid tournamentId, int id);

        PlayerStats GetPlayerStatsByName(string groupName, Guid tournamentId, string name);
    }
}
