using System.Threading;
using League.Com.Pages.Base;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class SchedulePage : PageBase
    {
        readonly IWebDriver _driver;
        public readonly SchedulePageMap Map;

        public SchedulePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            Map = new SchedulePageMap(driver);
        }

        public void Goto()
        {
            EsportsMenu.GotoNALCS();
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

        public IWebElement ScheduleTab => _driver.FindElement(By.CssSelector("[href='/en_US/na-lcs/na_2018_summer/schedule']"));

        public IWebElement StageDropdown => _driver.FindElement(By.CssSelector("[data-dropdown='drop-2']"));
    }
}
