using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class EsportsMenu
    {
        readonly IWebDriver _driver;
        public readonly EsportsMenuMap Map;

        public EsportsMenu(IWebDriver driver)
        {
            _driver = driver;
            Map = new EsportsMenuMap(driver);
        }

        public void GotoHome()
        {
            Map.HomeTab.Click();
        }

        public void GotoNALCS()
        {
            Map.NALCSTab.Click();
        }
    }

    public class EsportsMenuMap
    {
        readonly IWebDriver _driver;

        public EsportsMenuMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement HomeTab => _driver.FindElement(By.XPath("(//a[text()='HOME'])[last()]"));
        public IWebElement NALCSTab => _driver.FindElement(By.XPath("//a[text()='NA LCS']"));
    }
}
