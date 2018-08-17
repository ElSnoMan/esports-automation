using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Framework.Model;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class TeamsStandingsPage
    {
        readonly IWebDriver _driver;
        public readonly TeamsStandingsPageMap Map;

        public TeamsStandingsPage(IWebDriver driver)
        {
            _driver = driver;
            Map = new TeamsStandingsPageMap(driver);
        }

        public void Goto()
        {
            Map.TeamsStandingsTab.Click();
            WaitForPageLoad();
        }

        public void WaitForPageLoad()
        {
            Thread.Sleep(1000);
        }

        public TeamStanding GetTeamByName(string name)
        {

            var row = Map.TeamRows.FirstOrDefault(r => r.Text.Contains(name));
            var team = new TeamStanding
            {
                Rank = int.Parse(row.FindElement(By.CssSelector(".rank")).Text),
                Name = row.FindElement(By.CssSelector(".team-container")).Text,
                Record = row.FindElement(By.CssSelector(".record.show-for-large-up")).Text
            };

            return team;
        }

       
    }

    public class TeamsStandingsPageMap
    {
        readonly IWebDriver _driver;

        public TeamsStandingsPageMap(IWebDriver driver)
        {

            _driver = driver;

        }

        public IWebElement TeamsStandingsTab => _driver.FindElement(By.XPath("(//a[text()='TEAMS & STANDINGS']"));
        public IList<IWebElement> TeamRows => _driver.FindElements(By.XPath("(//div[contains(@class, 'team-row')]"));

    }
}
