using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Framework.Model;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class TicketsPage
    {
        readonly IWebDriver _driver;
        public readonly TicketsPageMap Map;

        public TicketsPage(IWebDriver driver)
        {
            _driver = driver;
            Map = new TicketsPageMap(driver);
        }

        public void Goto()
        {
            Map.TicketsTab.Click();
            WaitForPageLoad();
        }

        public void WaitForPageLoad()
        {
            Thread.Sleep(1000);
        }

       

        public class TicketsPageMap
        {
            readonly IWebDriver _driver;

            public TicketsPageMap(IWebDriver driver)
            {

                _driver = driver;

            }

            public IWebElement TicketsTab => _driver.FindElement(By.XPath("(//a[href='/en_US/tickets'"));

            //Tickets Sub Nav
            public IWebElement NALCSNav => _driver.FindElement(By.XPath("(//a[@id = 'nalcs'])]"));
            public IWebElement EULCSNav => _driver.FindElement(By.XPath("(//a[@id = 'eulcs'])]"));
            public IWebElement NALCSSummerNav => _driver.FindElement(By.XPath("(//a[@id = 'panel2'])]"));
            public IWebElement EULCSSummerNAV => _driver.FindElement(By.XPath("(//a[@id = 'panel3'])]"));
            public IWebElement TwentyEighteenSummerNav => _driver.FindElement(By.XPath("(//a[@id = 'panel4'])]"));

            //Ticket Tables
            public IList<IWebElement> TicketRow => _driver.FindElements(By.XPath("(//table[contains(@class, 'tickets-table')]"));
          


           


        }
    }
}
