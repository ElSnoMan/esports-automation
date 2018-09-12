using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace League.Merch.Pages
{
    public class HomePage
    {
        readonly IWebDriver _driver;
        readonly WebDriverWait _wait;

        public readonly HomePageMap Map;

        public HomePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            Map = new HomePageMap(_driver);
        }

        public void ClickHoodie()
        {
            Map.Hoodie.Click();
        }
    }

    public class HomePageMap
    {
        readonly IWebDriver _driver;

        public HomePageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Hoodie => _driver.FindElement(By.CssSelector("[href='arcade-pullover-hoodie.html']"));
    }
}
