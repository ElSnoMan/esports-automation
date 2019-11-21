using System.Linq;
using Framework.Model;
using Framework.Selenium;
using League.Com.Pages.Base;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class StandingsPage : PageBase
    {
        public readonly StandingsPageMap Map;

        public StandingsPage()
        {
            Map = new StandingsPageMap();
        }

        public void Goto()
        {
            Driver.Goto("https://watch.na.lolesports.com/standings");
            Driver.Wait.Until(drvr => Map.FirstLeague.Clickable);
        }

        public void SwitchTo(string league, string stage)
        {
            Map.LeagueByName(league).Click();
            Map.StageByName(stage).Click();

            Driver.Wait.Until(driver => Map.FirstRow.Displayed);
        }

        public TeamStanding FirstPlace => _generateTeamStandingFromRow(Map.FirstRow);

        public TeamStanding GetTeamByName(string name)
        {
            var row = Map.TeamRows.FirstOrDefault(r => r.Text.Contains(name));
            return _generateTeamStandingFromRow(row);
        }

        public bool ResultsDisplayed()
        {
            var result = false;

            foreach (var row in Map.TeamRows)
            {
                var rank = row.FindElement(By.CssSelector(".ordinal"));
                var name = row.FindElement(By.CssSelector(".team .name"));
                var record = row.FindElement(By.CssSelector(".team .record"));

                if (!rank.Displayed || !name.Displayed || !record.Displayed)
                {
                    result = false;
                    break;
                }

                result = true;
            }

            return result;
        }

        private TeamStanding _generateTeamStandingFromRow(Element row)
        {
            return new TeamStanding
            {
                Rank = int.Parse(row.FindElement(By.CssSelector(".ordinal")).Text),
                Name = row.FindElement(By.CssSelector(".team .name")).Text,
                Record = row.FindElement(By.CssSelector(".team .record")).Text
            };
        }
    }

    public class StandingsPageMap
    {
        // Leagues
        public Element FirstLeague => Driver.FindElement(By.CssSelector(".league"), "First League");
        public Elements Leagues => Driver.FindElements(By.CssSelector(".league"));

        public Element LeagueByName(string name) => Driver.FindElement(
                by: By.XPath($"//div[@class='name' and text()='{name}']"),
                elementName: $"{name} League Filter");

        public Element StageByName(string name) => Driver.FindElement(
            by: By.XPath($"//div[@class='stage-option' and text()='{name}']"),
            elementName: $"{name} Stage");

        // Teams
        public Element FirstRow => Driver.FindElement(By.CssSelector(".ranking"), "First Team");
        public Elements TeamRows => Driver.FindElements(By.CssSelector(".ranking"));

        // used if screen is too small
        public Element LeagueSelector => Driver.FindElement(By.CssSelector(".league-selector"));
    }
}
