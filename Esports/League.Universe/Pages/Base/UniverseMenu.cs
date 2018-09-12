using System;
using OpenQA.Selenium;

namespace League.Universe.Pages.Base
{
    public class UniverseMenu
    {
        readonly IWebDriver _driver;
        public readonly UniverseMenuMap Map;

        public UniverseMenu(IWebDriver driver)
        {
            _driver = driver;
            Map = new UniverseMenuMap(driver);
        }

        public void GoToFeatured()
        {
            Map.FeaturedLink.Click();
        }

        public void GoToChampions()
        {
            Map.ChampionsLink.Click();
        }

        public void GoToRegions()
        {
            Map.RegionsLink.Click();
        }

        public void GoToCollections()
        {
            Map.CollectionsLink.Click();
        }

        public void GoToMap()
        {
            Map.MapLink.Click();
        }

        public void GoToExplore()
        {
            Map.ExploreLink.Click();
        }

        public void GoToSearch()
        {
            Map.SearchLink.Click();
        }

        public void GoToLogin()
        {
            Map.LoginLink.Click();
        }

        public void GoToPayNow()
        {
            Map.PayNowButton.Click();
        }
    }

    public class UniverseMenuMap
    {
        readonly IWebDriver _driver;

        public UniverseMenuMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement HomeLink => _driver.FindElement(By.XPath(""));//not sure what how this works
        public IWebElement FeaturedLink => _driver.FindElement(By.XPath("//a[text()='FEATURED']"));
        public IWebElement ChampionsLink => _driver.FindElement(By.XPath("//a[text()='CHAMPIONS']"));
        public IWebElement RegionsLink => _driver.FindElement(By.XPath("//a[text()='REGIONS']"));//5
        public IWebElement CollectionsLink => _driver.FindElement(By.XPath("//a[text()='COLLECTIONS']"));
        public IWebElement MapLink => _driver.FindElement(By.XPath("//a[text()='MAP']"));
        public IWebElement ExploreLink => _driver.FindElement(By.XPath("//a[text()='EXPLORE']"));
        public IWebElement SearchLink => _driver.FindElement(By.XPath("//a[text()='SEARCH']"));
        public IWebElement LoginLink => _driver.FindElement(By.XPath("//a[text()='LOGIN']"));

        public IWebElement PayNowButton => _driver.FindElement(By.XPath("//"));
    }
}