using OpenQA.Selenium;

namespace League.Com.Pages.Base
{
    public class PageBase
    {
        readonly IWebDriver _driver;
        public readonly EsportsMenu EsportsMenu;

        public PageBase(IWebDriver driver)
        {
            _driver = driver;
            EsportsMenu = new EsportsMenu(driver);
        }
    }
}
