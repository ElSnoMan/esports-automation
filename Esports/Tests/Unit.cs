using System;
using Framework.Services;
using NUnit.Framework;
using Tests.Base;

namespace Tests
{
    [TestFixture]
    public class Unit : TestBase
    {
        [TestCase("regular_season")]
        [TestCase("playoffs")]
        [TestCase("regionals")]
        [Test, Category("unit"), Category("1")]
        public void Player_service_can_get_players(string stage)
        {
            IPlayerStatsService service = new PlayerService();
            Assert.IsNotNull(service.GetAllPlayerStats(stage, new Guid("8531db79-ade3-4294-ae4a-ef639967c393")));
        }

        [Test, Category("unit"), Category("2")]
        public void Player_service_can_get_player_by_id()
        {
            IPlayerStatsService service = new PlayerService();
            var player = service.GetPlayerStatsById("regular_season", new Guid("8531db79-ade3-4294-ae4a-ef639967c393"), id: 60);

            Assert.AreEqual("Bjergsen", player.Name);
        }

        [Test, Category("unit"), Category("3")]
        public void Player_service_can_get_player_by_name()
        {
            IPlayerStatsService service = new PlayerService();
            var player = service.GetPlayerStatsByName(
                groupName: "regular_season",
                tournamentId: new Guid("8531db79-ade3-4294-ae4a-ef639967c393"),
                name: "Bjergsen"
            );

            Assert.AreEqual(60, player.Id);
        }
    }
}