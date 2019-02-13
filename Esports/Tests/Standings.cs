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
            // LCS filter selected by default
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Team Liquid"));
        }

        [Test, Parallelizable]
        [Category("standings"), Category("demo")]
        public void Filter_by_LEC_region()
        {
            Esports.Standings.SwitchTo(Leagues.LEC);
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("G2 Esports"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_LCK_region()
        {
            Esports.Standings.SwitchTo(Leagues.LCK);
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Griffin"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_LPL_region()
        {
            Esports.Standings.SwitchTo(Leagues.LPL);
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("FunPlus Phoenix"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_LCS_academy()
        {
            Esports.Standings.SwitchTo(Leagues.LCS_ACADEMY);
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Team Liquid Academy"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_TCL_region()
        {
            Esports.Standings.SwitchTo(Leagues.TCL);
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Bahçeşehir SuperMassive"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_CBLOL_region()
        {
            Esports.Standings.SwitchTo(Leagues.CBLOL);
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Flamengo eSports"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_LLA_region()
        {
            Esports.Standings.SwitchTo(Leagues.LLA);
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("Infinity Esports"));
        }

        [Test, Parallelizable]
        [Category("standings")]
        public void Filter_by_OPL_region()
        {
            Esports.Standings.SwitchTo(Leagues.OPL);
            Assert.That(Esports.Standings.FirstPlace.Name.Equals("The Chiefs Esports Club"));
        }
    }
}
