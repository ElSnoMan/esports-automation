using System;
using OpenQA.Selenium;
using System.Threading;

namespace League.Com.Pages
{
    public class Schedule
    {
        IWebDriver _driver;
        public readonly ScheduleMap Map;

        public Schedule(IWebDriver driver)
        {
            _driver = driver;
            Map = new ScheduleMap(driver);

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

    public class ScheduleMap
    {
        
        IWebDriver _driver;

        public ScheduleMap(IWebDriver driver)
        {
            _driver = driver;
        }

            public IWebElement Schedule => _driver.FindElement(By.CssSelector("[href='/en_US/na-lcs/na_2018_summer/schedule']"));

            public IWebElement RegSeason => _driver.FindElement(By.CssSelector("[data-dropdown='drop-2']"));
    }
}
