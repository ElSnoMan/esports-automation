using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace League.Com.Driver_Core
{
    public static class Driver
    {
        public static void Init()
        {
            IWebDriver _driver = new ChromeDriver("");
        }

        public static IWebDriver Current => _driver ?? throw new Exception("Driver pooped out. Call Driver.Init()");
        public static String GetUrl => Current.Url;
        public static void GoTo(string url)
        {
            Current.Navigate().GoToUrl(url);
        }

        public static Close()
        {
            Current.Close();
        }
        public static Quit()
        {
            Current.Quit();
            Current.Dispose();
        }

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public static void ExecuteJavaScript(string js, params object[] args)
        {
            Current.ExecuteJavaScript(js, args);
        }

       


    }


}
