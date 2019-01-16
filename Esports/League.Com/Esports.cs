using System;
using OpenQA.Selenium;
using Framework.Selenium;
using League.Com.Pages;

namespace League.Com
{
    public static class Esports
    {
        [ThreadStatic] public static HomePage Home;

        [ThreadStatic] public static LeaguePage League;

        [ThreadStatic] public static StandingsPage Standings;

        public static void Init()
        {
            Home = new HomePage();
            League = new LeaguePage();
            Standings = new StandingsPage();
        }

        public static void Goto()
        {
            Driver.Goto("https://nexus.leagueoflegends.com/en-us/esports/");
            Driver.Wait.Until(driver => driver.FindElement(By.CssSelector("[data-riotbar-link-id='signup']")));
        }
    }
}
