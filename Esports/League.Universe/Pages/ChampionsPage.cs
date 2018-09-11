using System;
using System.Collections.Generic;
using League.Universe.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace League.Universe.Pages
{
    public class ChampionsPage
    {
        readonly IWebDriver _driver;
        readonly WebDriverWait _wait;
        public readonly ChampionsPageMap Map;
        public readonly UniverseMenu UniverseMenu;

        public ChampionsPage(IWebDriver driver, WebDriverWait wait)
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
            // what goes here? 
        }

        public IWebElement GetChampionByName(string name) // Aatrox
        {
            IWebElement card = null;

            foreach(var champion in Map.ChampionCards)
            {
                if (champion.Text.Contains(name.ToUpper()))
                {
                    card = champion;
                    break;
                }
            }

            return card;
        }
    }

    public class ChampionsPageMap
    {
        readonly IWebDriver _driver;

        public ChampionsPageMap(IWebDriver driver)
        {
            _driver = driver;

        }

        public IWebElement FirstChampionCard => _driver.FindElement(By.CssSelector("[class*='champsList'] > li"));

        public IList<IWebElement> ChampionCards => _driver.FindElements(By.CssSelector("[class*='champsList'] > li"));
    }
}