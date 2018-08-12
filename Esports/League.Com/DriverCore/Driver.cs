using System.Collections.Generic;
using Framework.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace League.Com.DriverCore
{
    public class Driver
    {
        readonly IWebDriver _driver;

        public Driver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            _driver = new ChromeDriver(Config.DRIVERPATH, options);
        }

        public IWebDriver Current => _driver;

        public string GetUrl => Current.Url;

        public void Goto(string url)
        {
            Current.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            Current.Close();
        }

        public void Quit()
        {
            Current.Quit();
            Current.Dispose();
        }

        public IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public void ExecuteJavaScript(string js, params object[] args)
        {
            Current.ExecuteJavaScript(js, args);
        }
    }
}
