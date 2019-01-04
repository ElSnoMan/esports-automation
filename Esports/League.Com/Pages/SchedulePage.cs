using System.Threading;
using Framework.Selenium;
using League.Com.Pages.Base;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class SchedulePage : PageBase
    {
        public readonly SchedulePageMap Map;

        public SchedulePage()
        {
            Map = new SchedulePageMap();
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
        public Element ScheduleTab => Driver.FindElement(By.CssSelector("[href='/en_US/na-lcs/na_2018_summer/schedule']"));
        public Element StageDropdown => Driver.FindElement(By.CssSelector("[data-dropdown='drop-2']"));
    }
}
