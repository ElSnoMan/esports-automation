using System.Linq;
using System.Threading;
using Framework.Model;
using Framework.Selenium;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class TeamsStandingsPage
    {
        public readonly TeamsStandingsPageMap Map;

        public TeamsStandingsPage()
        {
            Map = new TeamsStandingsPageMap();
        }

        public void Goto()
        {
            Driver.Wait.Until((drvr) => Map.TeamsStandingsTab.Displayed);
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
            Driver.FindElement(By.XPath($"//a[text '{name.ToLower()}']")).Click();
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

                if (!rank.Displayed || !name.Displayed || !record.Displayed)
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
        public Element TeamsStandingsTab => Driver.FindElement(By.XPath("//a[contains(text(), 'TEAMS & STANDINGS')]"));
        public Elements TeamRows => Driver.FindElements(By.XPath("(//div[contains(@class, 'team-row')]"));
        public Elements TeamRank => Driver.FindElements(By.XPath("//div[contains(@class, 'columns large-1 small-3 rank')]"));
        public Element StageDropDown => Driver.FindElement(By.XPath("//a[contains(@data-dropdown, 'drop-2')]"));
    }
}
