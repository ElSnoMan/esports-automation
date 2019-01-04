using League.Com;
using League.Com.Pages;
using NUnit.Framework;
using Tests.Base;

namespace Tests
{
    [TestFixture, Parallelizable]
    public class PlayerStats : TestBase
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            Esports.League.Goto("NA LCS");
            Esports.League.Stats.SwitchTo();
            Esports.League.Stats.SelectStage("Regular Season");
        }

        [Test, Parallelizable]
        [Category("playerstats"), Category("demo"), Category("foo")]
        public void Filtered_by_kda()
        {
            var (player, index) = Esports.League.Stats.GetPlayerByName("Wiggily");

            Assert.AreEqual(21.0, player.KDA);
            Assert.AreEqual(0, index);
        }

        [Test, Parallelizable]
        [Category("playerstats"), Category("foo")]
        public void Filtered_by_player_name()
        {
            var stats = Esports.League.Stats;

            stats.FilterByPlayerName("Bjergsen");
            var (player, index) = stats.GetPlayerByName("Bjergsen");

            Assert.AreEqual("TSM", player.Team);
            Assert.AreEqual(0, index);
        }

        [Test, Parallelizable]
        [Category("playerstats")]
        public void Filtered_by_team()
        {
            var stats = Esports.League.Stats;

            stats.FilterByTeam("100");

            foreach (var row in stats.Map.PlayerRows)
            {
                var player = stats.GetPlayerStatsFromRow(row);
                Assert.AreEqual("100", player.Team);
            }
        }

        [Test, Parallelizable]
        [Category("playerstats")]
        public void Filtered_by_position()
        {
            var stats = Esports.League.Stats;

            stats.FilterByPosition("ADC");

            foreach (var row in stats.Map.PlayerRows)
            {
                var player = stats.GetPlayerStatsFromRow(row);
                Assert.AreEqual("ADC", player.Position);
            }
        }

        [Test, Parallelizable]
        [Category("playerstats")]
        public void Ordered_by_kills()
        {
            var stats = Esports.League.Stats;

            stats.OrderTable(OrderBy.KILLS);
            var player = stats.GetFirstPlayer();

            Assert.AreEqual("Cody Sun", player.Name);
            Assert.AreEqual(85, player.Kills);
        }

        [Test, Parallelizable]
        [Category("playerstats")]
        public void Ordered_by_deaths()
        {
            var stats = Esports.League.Stats;

            stats.OrderTable(OrderBy.DEATHS);
            var player = stats.GetFirstPlayer();

            Assert.AreEqual("Fallenbandit", player.Name);
            Assert.AreEqual(1, player.Deaths);
        }

        [Test, Parallelizable]
        [Category("playerstats")]
        public void Ordered_by_assists()
        {
            var stats = Esports.League.Stats;

            stats.OrderTable(OrderBy.ASSISTS);
            var player = stats.GetFirstPlayer();

            Assert.AreEqual("Aphromoo", player.Name);
            Assert.AreEqual(169, player.Assists);
        }

        [Test, Parallelizable]
        [Category("playerstats")]
        public void Ordered_by_kill_participation()
        {
            var stats = Esports.League.Stats;

            stats.OrderTable(OrderBy.KILL_PARTICIPATION);
            var player = stats.GetFirstPlayer();

            Assert.AreEqual("Moon", player.Name);
            Assert.AreEqual(85.7, player.KillParticipation);
        }

        [Test, Parallelizable]
        [Category("playerstats")]
        public void Ordered_by_cs_per_minute()
        {
            var stats = Esports.League.Stats;

            stats.OrderTable(OrderBy.CS_PER_MINUTE);
            var player = stats.GetFirstPlayer();

            Assert.AreEqual("PowerOfEvil", player.Name);
            Assert.AreEqual(10.6, player.CsPerMin);
        }

        [Test, Parallelizable]
        [Category("playerstats")]
        public void Ordered_by_cs_total()
        {
            var stats = Esports.League.Stats;

            stats.OrderTable(OrderBy.CS_TOTAL);
            var player = stats.GetFirstPlayer();

            Assert.AreEqual("Cody Sun", player.Name);
            Assert.AreEqual(7644, player.Cs);
        }

        [Test, Parallelizable]
        [Category("playerstats")]
        public void Ordered_by_minutes_played()
        {
            var stats = Esports.League.Stats;

            stats.OrderTable(OrderBy.MINUTES_PLAYED);
            var player = stats.GetFirstPlayer();

            Assert.AreEqual("Aphromoo", player.Name);
            Assert.AreEqual(743, player.MinutesPlayed);
        }

        [Test, Parallelizable]
        [Category("playerstats")]
        public void Ordered_by_games_played()
        {
            var stats = Esports.League.Stats;

            stats.OrderTable(OrderBy.GAMES_PLAYED);
            var player = stats.GetFirstPlayer();

            Assert.AreEqual("Aphromoo", player.Name);
            Assert.AreEqual(20, player.GamesPlayed);
        }
    }
}
