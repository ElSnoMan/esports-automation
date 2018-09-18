using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Framework.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace League.Com.Pages
{
    public class TeamsStandingsPage
    {
        readonly IWebDriver _driver;
        readonly WebDriverWait _wait;
        public readonly TeamsStandingsPageMap Map;

        public TeamsStandingsPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            Map = new TeamsStandingsPageMap(driver);
        }

        public void Goto()
        {
            _wait.Until((drvr) => Map.TeamsStandingsTab.Displayed);
            Map.TeamsStandingsTab.Click();
            WaitForPageLoad();
        }

        public void WaitForPageLoad()
        {
            Thread.Sleep(1000);
        }

		public void SelectStageByName(string name)
        {
            Map.StageDropDown.Click();
			_driver.FindElement(By.XPath($"//a[text '{name.ToLower()}']")).Click();
			WaitForPageLoad();
        }
        
		public bool RegularSeasonResultsDisplayed()
		{
			var result = false;
			foreach (var row in Map.TeamRows)
            {
                var rank = row.FindElement(By.CssSelector(".rank"));
                var name = row.FindElement(By.CssSelector(".team-name"));
				var record = row.FindElement(By.CssSelector(".record"));                

				if(!rank.Displayed||!name.Displayed||!record.Displayed)
				{
					result = false;
					break;
				}

				result = true;            
            }

			return result;		
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

        public IWebElement TeamsStandingsTab => _driver.FindElement(By.XPath("//a[contains(text(), 'TEAMS & STANDINGS')]"));
        public IList<IWebElement> TeamRows => _driver.FindElements(By.XPath("(//div[contains(@class, 'team-row')]"));
		public IList<IWebElement> TeamRank => _driver.FindElements(By.XPath("//div[contains(@class, 'columns large-1 small-3 rank')]"));
        public IWebElement StageDropDown => _driver.FindElement(By.XPath("//a[contains(@data-dropdown, 'drop-2')]"));

    }
}
