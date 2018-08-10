using System;
using OpenQA.Selenium;
using System.Threading;

namespace League.Com.Pages
{
    public class SchedulePage
    {
        readonly IWebDriver _driver;
        public readonly SchedulePageMap Map;

        public SchedulePage(IWebDriver driver)
        {
            _driver = driver;
            Map = new SchedulePageMap(driver);
        }

        public void GoTo()
        {
            Map.Schedule.Click();
            WaitForPageLoad();
        }

        public void WaitForPageLoad()
        {
            Thread.Sleep(1000);
        }
    }

    public class SchedulePageMap
    {
        readonly IWebDriver _driver;

        public SchedulePageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Schedule => _driver.FindElement(By.CssSelector("[href='/en_US/na-lcs/na_2018_summer/schedule']"));

        public IWebElement RegSeason => _driver.FindElement(By.CssSelector("[data-dropdown='drop-2']"));
    }
}
