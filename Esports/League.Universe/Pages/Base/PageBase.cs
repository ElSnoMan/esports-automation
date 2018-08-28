using OpenQA.Selenium;

namespace League.Universe.Pages.Base
{
    public class PageBase
    {
        readonly IWebDriver _driver;
        public readonly UniverseMenu UniverseMenu;

        public PageBase(IWebDriver driver)
        {
            _driver = driver;
            UniverseMenu = new UniverseMenu(driver);
        }
    }
}