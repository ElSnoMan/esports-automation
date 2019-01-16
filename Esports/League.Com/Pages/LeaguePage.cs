using System;
using Framework.Selenium;
using League.Com.Pages.Base;

namespace League.Com.Pages
{
    public class LeaguePage : PageBase
    {
        public SchedulePage Schedule;
        public StandingsPage TeamStandings;
        public PlayerStatsPage Stats;

        public LeaguePage()
        {
            Schedule = new SchedulePage();
            TeamStandings = new StandingsPage();
            Stats = new PlayerStatsPage();
        }

        public void Goto(string league)
        {
            Driver.Goto("https://www.lolesports.com/en_US/na-lcs");
            //EsportsMenu.GotoNALCS();
        }
    }
}
