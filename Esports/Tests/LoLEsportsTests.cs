using System;
using System.Linq;
using Framework.Services;
using League.Com.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Tests.Base;
using Tests.Settings;

namespace Tests
{
    [TestFixture]
    public class LoLEsportsTests : TestBase
    {
        IWebDriver Driver;
        WebDriverWait Wait;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(Config.DRIVERPATH, options);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void Cleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }

        [Test, Category("lol")]
        public void Selenium_driver_is_up_and_running()
        {
            Driver.Navigate().GoToUrl("https://google.com");
            Driver.FindElement(By.Name("q")).SendKeys("lol esports");
            Driver.FindElement(By.Name("btnK")).Submit();
        }

        [Test, Category("tournament")]
        public void Compare_api_and_page_stats()
        {
            // start on NA LCS League Page
            Driver.Navigate().GoToUrl("https://www.lolesports.com/en_US/na-lcs");

            // get player stats from the Page
            var statsPage = new PlayerStatsPage(Driver, Wait);
            statsPage.SwitchTo();
            statsPage.SelectSplit("2018 Summer Split");
            statsPage.SelectStage("Regular Season");
            var bjergsenPage   = statsPage.GetPlayerStatsByName("Bjergsen");
            var doubleliftPage = statsPage.GetPlayerStatsByName("Doublelift");

            // get player stats from the API
            var statsApi = new PlayerService().GetAllPlayerStats(
                groupName: "regular_season",
                tournamentId: new Guid("8531db79-ade3-4294-ae4a-ef639967c393")
            );

            var bjergsenApi   = statsApi.First(player => player.Name == "Bjergsen");
            var doubleliftApi = statsApi.First(player => player.Name == "Doublelift");

            // compare the API stats to the Page stats
            Assert.AreEqual(Math.Round(bjergsenApi.KDA, 1), bjergsenPage.KDA);
            Assert.AreEqual(Math.Round(doubleliftApi.KDA, 1), doubleliftPage.KDA);
        }
    }
}
