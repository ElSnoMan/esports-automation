using System;
using System.Linq;
using Framework.Services;
using League.Com.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.Base;
using Tests.Settings;

namespace Tests
{
    [TestFixture]
    public class LoLEsportsTests : TestBase
    {
        IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(Config.DRIVERPATH, options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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
            Driver.Navigate().GoToUrl("https://www.lolesports.com/en_US/na-lcs/na_2018_summer/stats/regular_season");

            // get player stats from the Page using Selenium
            var statspage = new PlayerStatsPage(Driver);
            var bjergsenPageStats = statspage.GetPlayerStatsByName("Bjergsen");
            var doubleliftPageStats = statspage.GetPlayerStatsByName("Doublelift");

            // get player stats from the API
            var playerStats = new PlayerService().GetAllPlayerStats(
                groupName: "regular_season",
                tournamentId: new Guid("8531db79-ade3-4294-ae4a-ef639967c393")
            );

            var bjergsen = playerStats.First(p => p.Name == "Bjergsen");
            var doublelift = playerStats.First(p => p.Name == "Doublelift");

            // compare the API stats to the Page stats
            Assert.AreEqual(Math.Round(bjergsen.KDA, 1), bjergsenPageStats.KDA);
            Assert.AreEqual(Math.Round(doublelift.KDA, 1), doubleliftPageStats.KDA);
        }
    }
}
