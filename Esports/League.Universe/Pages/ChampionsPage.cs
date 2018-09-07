using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace League.Universe.Pages.Base
{
    public class ChampionsPage
    {
        readonly IWebDriver _driver;
        readonly WebDriverWait _wait;
        public readonly ChampionsPageMap Map;
        public readonly UniverseMenu UniverseMenu;

        public ChampionsPage(IWebDriver driver)
        {
            _driver = driver;
            Map = new ChampionsPageMap(driver);
            UniverseMenu = new UniverseMenu(driver);
        }

        public void Goto()
        {
            UniverseMenu.GoToChampions();
            SwitchTo();
        }

        public void WaitForPageLoad()
        {

        }

        public void SwitchTo()
        {

        }

        public void GetChampionsByName()
        {

        }
    }

    public class ChampionsPageMap
    {
        readonly IWebDriver _driver;

        public ChampionsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}