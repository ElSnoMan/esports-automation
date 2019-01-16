using Framework.Selenium;
using OpenQA.Selenium;

namespace League.Com.Pages.Base
{
    public class WatchMenu
    {
        public Element WatchLink => Driver.FindElement(By.CssSelector(".item.link.watch"), "Watch Nav Link");
        public Element ScheduleLink => Driver.FindElement(By.CssSelector(".item.link.schedule"), "Schedule Nav Link");
        public Element VodsLink => Driver.FindElement(By.CssSelector(".item.link.vods"), "VODS Nav Link");
        public Element StandingsLink => Driver.FindElement(By.CssSelector(".item.link.standings"), "Standings Nav Link");
        public Element RewardsLink => Driver.FindElement(By.CssSelector(".item.link.rewards"), "Rewards Nav Link");
        public Element NewsLink => Driver.FindElement(By.CssSelector(".item.link.news"), "News Nav Link");
    }
}
