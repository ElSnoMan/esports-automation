using System.Linq;
using System.Threading;
using League.Com.Pages.Base;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class PlayerStatsPage : PageBase
    {
        readonly IWebDriver _driver;
        public readonly PlayerStatsPageMap Map;

        public PlayerStatsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            Map = new PlayerStatsPageMap(driver);
        }

        public void Goto()
        {
            Map.StatsTab.Click();
            WaitForPageLoad();
        }

        public void SelectSplit(string name)
        {
            Map.SplitDropDown.Click();
            Map.SplitMenu.FindElements(By.TagName("a"))
               .FirstOrDefault(split => split.Text.Contains(name)).Click();

            WaitForLoad();
        }

        public void SelectStage(int index)
        {
            Map.StageDropDown.Click();
            Map.StageMenu.FindElements(By.TagName("a"))[index].Click();

            WaitForLoad();
        }

        public void WaitForPageLoad()
        {
            Thread.Sleep(1000);
        }

        void WaitForLoad()
        {
            // wait for subview to load
            Thread.Sleep(1000);
        }

    }

    public class PlayerStatsPageMap
    {
        readonly IWebDriver _driver;

        public PlayerStatsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement StatsTab => _driver.FindElement(By.XPath("(//a[text()='STATS'])[last()]"));
        public IWebElement SplitDropDown => _driver.FindElement(By.XPath("//a[@data-dropdown='drop-1']"));
        public IWebElement SplitMenu => _driver.FindElement(By.Id("drop-1"));
        public IWebElement StageDropDown => _driver.FindElement(By.XPath("//a[@data-dropdown='drop-2']"));
        public IWebElement StageMenu => _driver.FindElement(By.Id("drop-2"));
    }
}
