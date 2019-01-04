using System;
using System.Linq;
using Framework.Selenium;
using Framework.Services;
using League.Com.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Base;

namespace Tests
{
    [TestFixture]
    public class LoLEsportsTests : TestBase
    {
        [Test, Category("lol")]
        public void Selenium_driver_is_up_and_running()
        {
            Driver.Goto("https://google.com");
            Driver.FindElement(By.Name("q")).SendKeys("lol esports");
            Driver.FindElement(By.Name("btnK")).Submit();
        }

        [Test, Category("tournament")]
        public void Compare_api_and_page_stats()
        {
            Driver.Goto("https://www.lolesports.com/en_US/na-lcs");

            // get player stats from the Page
            var statsPage = new PlayerStatsPage();
            statsPage.SwitchTo();
            statsPage.SelectSplit("2018 Summer Split");
            statsPage.SelectStage("Regular Season");
            var bjergsenPage = statsPage.GetPlayerByName("Bjergsen");
            var doubleliftPage = statsPage.GetPlayerByName("Doublelift");

            // get player stats from the API
            var statsApi = new PlayerService().GetAllPlayerStats(
                groupName: "regular_season",
                tournamentId: "8531db79-ade3-4294-ae4a-ef639967c393"
            );

            //var statsApi = new PlayerService().GetAllPlayerStats(
            //    groupName: "playoffs",
            //    tournamentId: "8531db79-ade3-4294-ae4a-ef639967c393"
            //);

            var bjergsenApi = statsApi.First(player => player.Name == "Bjergsen");
            var doubleliftApi = statsApi.First(player => player.Name == "Doublelift");

            // compare the API stats to the Page stats
            Assert.AreEqual(Math.Round(bjergsenApi.KDA, 1), bjergsenPage.player.KDA);
            Assert.AreEqual(Math.Round(doubleliftApi.KDA, 1), doubleliftPage.player.KDA);
        }

        [Test, Category("regular Season")]
        public void Teams_displayed_with_name_rank_record()
        {
            Driver.Goto("https://www.lolesports.com/en_US/");
            var home = new LolEsportsHomePage();
            home.EsportsMenu.GotoNALCS();         
            var teamStandings = new TeamsStandingsPage();
            teamStandings.Goto();
            teamStandings.SelectStageByName("regular season");
            Assert.IsTrue(teamStandings.RegularSeasonResultsDisplayed());
        }
    }
}
