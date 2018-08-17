using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class EsportsMenu
    {
        readonly IWebDriver _driver;
        public readonly EsportsMenuMap Map;

        public EsportsMenu(IWebDriver driver)
        {
            _driver = driver;
            Map = new EsportsMenuMap(driver);
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

        public void GotoNASoutingGrounds()
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
        readonly IWebDriver _driver;

        public EsportsMenuMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement HomeLink => _driver.FindElement(By.XPath("(//a[text()='HOME'])[last()]"));
        public IWebElement NALCSLink => _driver.FindElement(By.XPath("//a[text()='NA LCS']"));
        public IWebElement EULCSLink => _driver.FindElement(By.XPath("//a[text()='EU LCS']"));
        public IWebElement LCKLink => _driver.FindElement(By.CssSelector("[href='/en_US/lck']"));
        public IWebElement LPLLink => _driver.FindElement(By.CssSelector("[href='/en_US/lpl']"));
        public IWebElement LMSLink => _driver.FindElement(By.CssSelector("[href='/en_US/lms']"));
        public IWebElement NAAcademyLink => _driver.FindElement(By.CssSelector("[href='/en_US/na-academy']"));
        public IWebElement MidSeasonInvitationalLink => _driver.FindElement(By.CssSelector("[href='/en_US/msi']"));
        public IWebElement RiftRivalsLink => _driver.FindElement(By.CssSelector("[href='/en_US/rift-rivals']"));
        public IWebElement WorldChampionshipLink => _driver.FindElement(By.CssSelector("[href='/en_US/worlds']"));
        public IWebElement AllStarEventLink => _driver.FindElement(By.CssSelector("[href='/en_US/all-star']"));
        public IWebElement NAScoutingGroundsLink => _driver.FindElement(By.CssSelector("[href='/en_US/na-scouting-grounds']"));
        public IWebElement TicketsLink => _driver.FindElement(By.XPath("(//a[text()='Tickets'])[last()]"));

    }
}
