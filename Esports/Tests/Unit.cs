using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Database;
using Framework.Interface;

namespace Tests
{
    [TestClass]
    public class Unit
    {
        [TestMethod, TestCategory("unit")]
        public void Player_service_can_get_player()
        {
            IPlayerService service = new LocalPlayerService();
            Assert.AreEqual(service.GetPlayer().Summoner, "Impact");
        }
    }
}
