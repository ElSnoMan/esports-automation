using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Services;
using Tests.Base;

namespace Tests
{
    [TestClass]
    public class Unit : TestBase
    {
        [TestMethod, TestCategory("unit")]
        public void Player_service_can_get_players()
        {
            IPlayerService service = new LocalPlayerService();
            Assert.IsNotNull(service.GetAllPlayerStats());
        }

        [TestMethod, TestCategory("unit")]
        public void Player_service_can_get_player_by_id()
        {
            IPlayerService service = new LocalPlayerService();
            var player = service.GetPlayerStatsById(60);

            Assert.AreEqual(player.Name, "Bjergsen");
        }

        [TestMethod, TestCategory("unit")]
        public void Player_service_can_get_player_by_name()
        {
            IPlayerService service = new LocalPlayerService();
            var player = service.GetPlayerStatsByName("Bjergsen");

            Assert.AreEqual(player.Id, 60);
        }
    }
}
