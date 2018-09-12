using OpenQA.Selenium;

namespace League.Com.Pages.Base
{
    public class PageBase
    {
        readonly IWebDriver _driver;
        public readonly EsportsMenu EsportsMenu;
        public readonly LolMenu LolMenu;

        public PageBase(IWebDriver driver)
        {
            _driver = driver;
            EsportsMenu = new EsportsMenu(driver);
            LolMenu = new LolMenu(driver);
        }
    }
}