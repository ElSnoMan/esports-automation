using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Framework.Model;
using League.Com.Pages.Base;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class PlayerStatsPage : PageBase
    {
        readonly IWebDriver _driver;
        public readonly PlayerStatsPageMap Map;

        public PlayerStatsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            Map = new PlayerStatsPageMap(driver);
        }

        public void Goto()
        {
            Map.StatsTab.Click();
            WaitForPageLoad();
        }

        public PlayerStats GetPlayerName(string name)
        {
            var row = Map.PlayerRows.FirstOrDefault(r => r.Text.Contains(name));
            var cells = row.FindElements(By.TagName("td"));
            var player = new PlayerStats();

            player.Name = cells[0].Text;
            player.Team = cells[1].Text;
            player.Position = cells[2].Text;
            player.KDA = Convert.ToDouble(cells[3].Text);
            player.Kills = Convert.ToInt32(cells[4].Text);
            player.Deaths = Convert.ToInt32(cells[5].Text);
            player.Assists = Convert.ToInt32(cells[6].Text);
            player.KillParticipation = Convert.ToDouble(cells[7].Text);
            player.CsPerMin = Convert.ToDouble(cells[8].Text);
            player.Cs = Convert.ToInt32(cells[9].Text);
            player.MinutesPlayed = Convert.ToInt32(cells[10].Text);
            player.GamesPlayed = Convert.ToInt32(cells[11].Text);

            return player;
        }

        public void SelectSplit(string name)
        {
            Map.SplitDropDown.Click();
            Map.SplitMenu.FindElements(By.TagName("a"))
               .FirstOrDefault(split => split.Text.Contains(name)).Click();

            WaitForLoad();
        }

        public void SelectStage(int index)
        {
            Map.StageDropDown.Click();
            Map.StageMenu.FindElements(By.TagName("a"))[index].Click();

            WaitForLoad();
        }

        public void WaitForPageLoad()
        {
            Thread.Sleep(1000);
        }

        void WaitForLoad()
        {
            // wait for subview to load
            Thread.Sleep(1000);
        }

    }

    public class PlayerStatsPageMap
    {
        readonly IWebDriver _driver;

        public PlayerStatsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement StatsTab => _driver.FindElement(By.XPath("(//a[text()='STATS'])[last()]"));
        public IWebElement SplitDropDown => _driver.FindElement(By.XPath("//a[@data-dropdown='drop-1']"));
        public IWebElement SplitMenu => _driver.FindElement(By.Id("drop-1"));
        public IWebElement StageDropDown => _driver.FindElement(By.XPath("//a[@data-dropdown='drop-2']"));
        public IWebElement StageMenu => _driver.FindElement(By.Id("drop-2"));

        public IList<IWebElement>PlayerRows  => _driver.FindElements(By.XPath("//tbody//tr"));
    }
}
