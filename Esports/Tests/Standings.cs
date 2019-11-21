using Framework.Constants;
using NUnit.Framework;
using Tests.Base;

namespace League.Com.Tests
{
    [TestFixture, Parallelizable]
    public class Standings : TestBase
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            Esports.Standings.Goto();
        }

        [Test, Parallelizable]
        [Category("standings"), Category("demo"), Category("lcs")]
        public void Filter_by_LCS_region()
        {
            Esports.Standings.SwitchTo(Leagues.LCS, "Regular Season");
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Team Liquid"));
        }

        [Test, Parallelizable]
        [Category("standings"), Category("demo")]
        public void Filter_by_LEC_region()
        {
            Esports.Standings.SwitchTo(Leagues.LEC, "Regular Season");
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("G2 Esports"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_LCK_region()
        {
            Esports.Standings.SwitchTo(Leagues.LCK, "Regular Season");
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Griffin"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_LPL_region()
        {
            Esports.Standings.SwitchTo(Leagues.LPL, "Regular Season");
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("FunPlus Phoenix"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_LCS_academy()
        {
            Esports.Standings.SwitchTo(Leagues.LCS_ACADEMY, "Regular Season");
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Cloud9 Academy"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_TCL_region()
        {
            Esports.Standings.SwitchTo(Leagues.TCL, "Regular Season");
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Royal Youth"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_CBLOL_region()
        {
            Esports.Standings.SwitchTo(Leagues.CBLOL, "Regular Season");
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Flamengo eSports"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_LLA_region()
        {
            Esports.Standings.SwitchTo(Leagues.LLA, "Regular Season");
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Isurus Gaming"));
        }
    }
}
