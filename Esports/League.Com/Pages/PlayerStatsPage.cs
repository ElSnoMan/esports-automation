using System;
using System.Linq;
using Framework.Model;
using Framework.Selenium;
using League.Com.Pages.Base;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class PlayerStatsPage : PageBase
    {
        public readonly PlayerStatsPageMap Map;

        public PlayerStatsPage()
        {
            Map = new PlayerStatsPageMap();
        }

        public void Goto()
        {
            // deprecated: EsportsMenu.GotoNALCS();
            SwitchTo();
        }

        public void FilterByPlayerName(string name)
        {
            Map.NameFilterButton.Click();
            SelectFilter(name);
        }

        public void FilterByPosition(string position)
        {
            Map.PositionFilterButton.Click();
            SelectFilter(position);
        }

        public void FilterByTeam(string team)
        {
            Map.TeamFilterButton.Click();
            SelectFilter(team);
        }

        public PlayerStats GetFirstPlayer()
        {
            var row = Map.PlayerRows.First();
            return GetPlayerStatsFromRow(row);
        }

        public (PlayerStats player, int index) GetPlayerByName(string name)
        {
            var row = Map.PlayerRows.FirstOrDefault(r => r.Text.Contains(name));
            var index = Map.PlayerRows.IndexOf(row);

            var player = GetPlayerStatsFromRow(row);
            return (player, index);
        }

        public void OrderTable(OrderBy by)
        {
            switch (by)
            {
                case OrderBy.ASSISTS:
                    Map.AssistsColumn.Click();
                    break;

                case OrderBy.CS_PER_MINUTE:
                    Map.CsPerMinuteColumn.Click();
                    break;

                case OrderBy.CS_TOTAL:
                    Map.CsTotalColumn.Click();
                    break;

                case OrderBy.DEATHS:
                    Map.DeathsColumn.Click();
                    break;

                case OrderBy.KDA:
                    Map.KdaColumn.Click();
                    break;

                case OrderBy.KILLS:
                    Map.KillsColumn.Click();
                    break;

                case OrderBy.KILL_PARTICIPATION:
                    Map.KillParticipationColumn.Click();
                    break;

                case OrderBy.NAME:
                    Map.OrderNameColumn.Click();
                    break;

                case OrderBy.POSITION:
                    Map.OrderPositionColumn.Click();
                    break;

                case OrderBy.TEAM:
                    Map.OrderTeamColumn.Click();
                    break;

                case OrderBy.MINUTES_PLAYED:
                    Map.MinutesPlayedColumn.Click();
                    break;

                case OrderBy.GAMES_PLAYED:
                    Map.GamesPlayedColumn.Click();
                    break;
            }

            WaitForStatsLoad();
        }

        public void SelectSplit(string name)
        {
            Map.SplitDropDown.Click();
            Map.SplitMenu.FindElements(By.TagName("a"))
               .FirstOrDefault(split => split.Text.Contains(name)).Click();

            WaitForStatsLoad();
        }

        public void SelectStage(int index)
        {
            Map.StageDropDown.Click();
            Map.StageMenu.FindElements(By.TagName("a"))[index].Click();

            WaitForStatsLoad();
        }

        public void SelectStage(string name)
        {
            Map.StageDropDown.Click();
            Map.StageMenu.FindElements(By.TagName("a"))
               .FirstOrDefault(stage => stage.Text.Contains(name)).Click();

            WaitForStatsLoad();
        }

        public void SwitchTo()
        {
            Driver.Wait.Until((drvr) => Map.StatsTab.Displayed);
            Map.StatsTab.Click();
            WaitForPageLoad();
        }

        public void WaitForPageLoad()
        {
            Driver.Wait.Until((drvr) => Map.PageSelectionContainer.Displayed);
        }

        public PlayerStats GetPlayerStatsFromRow(Element Row)
        {
            var cells = Row.FindElements(By.TagName("td"));
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

        void SelectFilter(string term)
        {
            Map.FilterMenuSearchField.SendKeys(term);
            Map.FilterMenuCheckboxByText(term).Click();
            Map.FilterMenuUpdateButton.Click();
            WaitForStatsLoad();
        }

        void WaitForStatsLoad()
        {
            try
            {
                var comingsoon = Driver.FindElement(By.CssSelector(".placeholder-page-container"));
                Console.WriteLine(comingsoon.Text);
            }
            catch
            {
                Driver.Wait.Until((drvr) => Map.StatsContainer.Displayed);
            }
        }

        int _parseInt(string text)
        {
            var parsed = int.TryParse(text, out int result);
            return parsed ? result : 0;
        }
    }

    public class PlayerStatsPageMap
    {
        public Element PageSelectionContainer => Driver.FindElement(By.Id("page-selection"), "Page Selection Container");
        public Element StatsContainer => Driver.FindElement(By.Id("stats-page"), "Stats Container");
        public Element StatsTab => Driver.FindElement(By.XPath("(//a[text()='STATS'])[last()]"), "Stats Tab");
        public Element SplitDropDown => Driver.FindElement(By.XPath("//a[@data-dropdown='drop-1']"), "Split Dropdown");
        public Element SplitMenu => Driver.FindElement(By.Id("drop-1"), "Split Menu");
        public Element StageDropDown => Driver.FindElement(By.XPath("//a[@data-dropdown='drop-2']"), "Stage Dropdown");
        public Element StageMenu => Driver.FindElement(By.Id("drop-2"), "Stage Menu");

        public Elements PlayerRows => Driver.FindElements(By.XPath("//tbody//tr"));

        /*
         * Table Filters
        */

        // Filter Menu (shared across Name, Team, and Position columns)
        public Element FilterMenuCheckAll => Driver.FindElement(By.CssSelector(".filter-menu.is-open > filter-checkbox.all"), "All Checkbox");
        public Element FilterMenuSearchField => Driver.FindElement(By.CssSelector(".filter-menu.is-open > .filter-search > input"), "Seach Filter Field");
        public Elements FilterMenuCheckboxes => Driver.FindElements(By.XPath("//*[@class='filter-menu is-open ']/div[@class='filter-options']/label[@class='filter-checkbox ']"));
        public Element FilterMenuCheckboxByText(string text) => Driver.FindElement(By.XPath($"//*[@class='filter-menu is-open ']/div[@class='filter-options']/label[@class='filter-checkbox ']/span[text()='{text}']"), $"Filter Checkbox - {text}");
        public Element FilterMenuUpdateButton => Driver.FindElement(By.CssSelector(".filter-menu.is-open > .filter-button-group > .update"), "Update Filter Button");
        public Element FilterMenuCancelButton => Driver.FindElement(By.CssSelector(".filter-menu.is-open > .filter-button-group > .cancel"), "Close Filter Menu Button");

        // Name column
        public Element NameFilterButton => Driver.FindElement(By.XPath("//*[@class='column-name' and text()='Name']")).Parent.FindElement(By.TagName("button"), "Name Filter Menu Button");
        public Element OrderNameColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and text()='Name']"), "Order by Name Button");

        // Team column
        public Element TeamFilterButton => Driver.FindElement(By.XPath("//*[@class='column-name' and text()='Team']")).Parent.FindElement(By.TagName("button"), "Team Filter Menu Button");
        public Element OrderTeamColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and text()='Team']"), "Order by Team Button");

        // Position column
        public Element PositionFilterButton => Driver.FindElement(By.XPath("//*[@class='column-name' and text()='Position']")).Parent.FindElement(By.TagName("button"), "Position Filter Menu Button");
        public Element OrderPositionColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and text()='Position']"), "Order by Position Button");

        // Column Headers to Order By
        public Element KdaColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and contains(text(), 'KDA')]"), "Order by KDA Button");
        public Element KillsColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and contains(text(), 'Kills')]"), "Order by Kills Button");
        public Element DeathsColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and contains(text(), 'Deaths')]"), "Order by Deaths Button");
        public Element AssistsColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and contains(text(), 'Assists')]"), "Order by Assists Button");
        public Element KillParticipationColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and contains(text(), 'Kill Participation')]"), "Order by Kill Participation Button");
        public Element CsPerMinuteColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and contains(text(), 'CS (per minute)')]"), "Order by CS/min Button");
        public Element CsTotalColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and contains(text(), 'CS (total)')]"), "Order by CS Total Button");
        public Element MinutesPlayedColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and contains(text(), 'Minutes Played')]"), "Order by Minutes Played Button");
        public Element GamesPlayedColumn => Driver.FindElement(By.XPath("//*[@class='column-name' and contains(text(), 'Games Played')]"), "Order by Games Played Button");
    }

    public enum OrderBy
    {
        NAME,
        TEAM,
        POSITION,
        KDA,
        KILLS,
        DEATHS,
        ASSISTS,
        KILL_PARTICIPATION,
        CS_PER_MINUTE,
        CS_TOTAL,
        MINUTES_PLAYED,
        GAMES_PLAYED
    }
}
