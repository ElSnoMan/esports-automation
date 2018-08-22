using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.Settings;
using Tests.Base;

namespace Tests
{
    [TestFixture]
    public class LoLEsportsTests : TestBase
    {
        IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(Config.DRIVERPATH, options);
        }

        [TearDown]
        public void Cleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }

        [Test, Category("lol")]
        public void Selenium_driver_is_up_and_running()
        {
            Driver.Navigate().GoToUrl("https://google.com");
            Driver.FindElement(By.Name("q")).SendKeys("lol esports");
            Driver.FindElement(By.Name("btnK")).Submit();
        }
    }
}
