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
            EsportsMenu.GotoNALCS();
            Map.StatsTab.Click();
            WaitForPageLoad();
        }

        public PlayerStats GetPlayerStatsByName(string name)
        {
            var row = Map.PlayerRows.FirstOrDefault(r => r.Text.Contains(name));
            var cells = row.FindElements(By.TagName("td"));
            var player = new PlayerStats
            {
                Name = cells[0].Text,
                Team = cells[1].Text,
                Position = cells[2].Text,
                KDA = double.Parse(cells[3].Text),
                Kills = _parseInt(cells[4].Text),
                Deaths = _parseInt(cells[5].Text),
                Assists = _parseInt(cells[6].Text),
                KillParticipation = double.Parse(cells[7].Text.Replace("%", "")),
                CsPerMin = double.Parse(cells[8].Text),
                Cs = _parseInt(cells[9].Text.Replace(",", "")),
                MinutesPlayed = _parseInt(cells[10].Text),
                GamesPlayed = _parseInt(cells[11].Text)
            };

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

        public void SelectStage(string name)
        {
            Map.StageDropDown.Click();
            Map.StageMenu.FindElements(By.TagName("a"))
               .FirstOrDefault(stage => stage.Text.Contains(name)).Click();

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

        int _parseInt(string text)
        {
            var parsed = int.TryParse(text, out int result);
            return parsed ? result : 0;
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

        public IList<IWebElement>PlayerRows => _driver.FindElements(By.XPath("//tbody//tr"));
    }
}
