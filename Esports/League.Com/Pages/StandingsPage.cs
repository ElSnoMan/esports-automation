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
            Driver.Wait.Until(driver => WatchMenu.StandingsLink.Displayed);
            Driver.Wait.Until(driver => Map.FirstRow.Displayed);
        }

        public void SwitchTo(string league)
        {
            try
            {
                Map.LeagueSelector.Click();
            }
            catch
            {
                // League Selector not needed
            }

            Driver.FindElement(
                by: By.XPath($"//div[@class='name' and text()='{league}']"),
                elementName: $"{league} League Filter")
                .Click();

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
            var team = new TeamStanding
            {
                Rank = int.Parse(row.FindElement(By.CssSelector(".ordinal")).Text),
                Name = row.FindElement(By.CssSelector(".team .name")).Text,
                Record = row.FindElement(By.CssSelector(".team .record")).Text
            };

            return team;
        }
    }

    public class StandingsPageMap
    {
        public Element FirstRow => Driver.FindElement(By.CssSelector(".ranking"));
        public Elements TeamRows => Driver.FindElements(By.CssSelector(".ranking"));

        // used if screen is too small
        public Element LeagueSelector => Driver.FindElement(By.CssSelector(".league-selector"));
    }
}
