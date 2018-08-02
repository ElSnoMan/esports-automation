using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.Settings;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver Driver;

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(Config.DRIVERPATH, options);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
