using League.Com.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace Merchandising.Pages.Base
{
    public class MerchActions
    {
        readonly IWebDriver _driver;
        readonly WebDriverWait _wait;
        public readonly MerchActionsMap Map;
        public MerchActions(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
            Map = new MerchActionsMap(_driver);


        }

        public void ClickHoodie()
        {
            Map.hoodie.Click();
        }

       // $("[href='arcade-pullover-hoodie.html']").click()
    }

    public class MerchActionsMap
    {
        readonly IWebDriver _driver;
        public MerchActionsMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement hoodie => _driver.FindElement(By.CssSelector("[href='arcade-pullover-hoodie.html']"));
    }
}
