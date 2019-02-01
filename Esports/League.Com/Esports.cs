using System;
using Framework.Selenium;
using League.Com.Pages;

namespace League.Com
{
    public static class Esports
    {
        [ThreadStatic] public static HomePage Home;

        [ThreadStatic] public static ServiceStatusPage ServiceStatus;

        [ThreadStatic] public static StandingsPage Standings;

        [ThreadStatic] public static SupportPage Support;

        [ThreadStatic] public static TicketsPage Tickets;

        public static void Init()
        {
            Home = new HomePage();
            ServiceStatus = new ServiceStatusPage();
            Standings = new StandingsPage();
            Support = new SupportPage();
            Tickets = new TicketsPage();
        }

        public static void Goto()
        {
            Driver.Goto("https://nexus.leagueoflegends.com/en-us/esports/");
            Driver.Wait.Until(driver => Home.Map.PlayNowSignupButton.Displayed);
        }
    }
}
