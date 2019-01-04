using Framework.Selenium;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class EsportsMenu
    {
        public readonly EsportsMenuMap Map;

        public EsportsMenu()
        {
            Map = new EsportsMenuMap();
        }

        public void GotoHome()
        {
            Map.HomeLink.Click();
        }

        public void GotoNALCS()
        {
            Map.NALCSLink.Click();
        }

        public void GotoEULCS()
        {
            Map.EULCSLink.Click();
        }

        public void GotoMidSeasonInvitational()
        {
            Map.MidSeasonInvitationalLink.Click();
        }

        public void GotoLCK()
        {
            Map.LCKLink.Click();
        }

        public void GotoLPL()
        {
            Map.LPLLink.Click();
        }

        public void GotoLMS()
        {
            Map.LMSLink.Click();
        }

        public void GotoNAAcademy()
        {
            Map.NAAcademyLink.Click();
        }

        public void GotoRiftRivals()
        {
            Map.RiftRivalsLink.Click();
        }

        public void GotoWorldChampionship()
        {
            Map.WorldChampionshipLink.Click();
        }

        public void GotoAllStarEvent()
        {
            Map.AllStarEventLink.Click();
        }

        public void GotoNAScoutingGrounds()
        {
            Map.NAScoutingGroundsLink.Click();
        }

        public void GotoTickets()
        {
            Map.TicketsLink.Click();
        }
    }

    public class EsportsMenuMap
    {
        public Element HomeLink => Driver.FindElement(By.XPath("(//a[text()='HOME'])[last()]"));
        public Element NALCSLink => Driver.FindElement(By.XPath("//a[text()='NA LCS']"));
        public Element EULCSLink => Driver.FindElement(By.XPath("//a[text()='EU LCS']"));
        public Element LCKLink => Driver.FindElement(By.CssSelector("[href='/en_US/lck']"));
        public Element LPLLink => Driver.FindElement(By.CssSelector("[href='/en_US/lpl']"));
        public Element LMSLink => Driver.FindElement(By.CssSelector("[href='/en_US/lms']"));
        public Element NAAcademyLink => Driver.FindElement(By.CssSelector("[href='/en_US/na-academy']"));
        public Element MidSeasonInvitationalLink => Driver.FindElement(By.CssSelector("[href='/en_US/msi']"));
        public Element RiftRivalsLink => Driver.FindElement(By.CssSelector("[href='/en_US/rift-rivals']"));
        public Element WorldChampionshipLink => Driver.FindElement(By.CssSelector("[href='/en_US/worlds']"));
        public Element AllStarEventLink => Driver.FindElement(By.CssSelector("[href='/en_US/all-star']"));
        public Element NAScoutingGroundsLink => Driver.FindElement(By.CssSelector("[href='/en_US/na-scouting-grounds']"));
        public Element TicketsLink => Driver.FindElement(By.XPath("(//a[text()='Tickets'])[last()]"));
    }
}
