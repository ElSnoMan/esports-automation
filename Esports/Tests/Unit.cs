using System;
using Framework.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Base;

namespace Tests
{
    [TestClass]
    public class Unit : TestBase
    {
        [DataRow("regular_season")]
        [DataRow("playoffs")]
        [DataRow("regionals")]
        [DataTestMethod, TestCategory("unit")]
        public void Player_service_can_get_players(string stage)
        {
            IPlayerStatsService service = new PlayerService(stage, new Guid("8531db79-ade3-4294-ae4a-ef639967c393"));
            Assert.IsNotNull(service.GetAllPlayerStats());
        }

        [TestMethod, TestCategory("unit")]
        public void Player_service_can_get_player_by_id()
        {
            IPlayerStatsService service = new PlayerService("regular_season", new Guid("8531db79-ade3-4294-ae4a-ef639967c393"));
            var player = service.GetPlayerStatsById(id: 60);

            Assert.AreEqual("Bjergsen", player.Name);
        }

        [TestMethod, TestCategory("unit")]
        public void Player_service_can_get_player_by_name()
        {
            IPlayerStatsService service = new PlayerService(
                groupName: "regular_season",
                tournamentId: new Guid("8531db79-ade3-4294-ae4a-ef639967c393")
            );
            var player = service.GetPlayerStatsByName(name: "Bjergsen");

            Assert.AreEqual(60, player.Id);
        }
    }
}