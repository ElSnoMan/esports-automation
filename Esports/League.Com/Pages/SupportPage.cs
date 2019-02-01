using System;
using Framework.Selenium;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class SupportPage
    {
        public readonly SupportPageMap Map;

        public SupportPage()
        {
            Map = new SupportPageMap();
        }

        public void Goto()
        {
            Map.ExploreMenu.Hover();
            Map.SupportLink.Click();
        }
    }

    public class SupportPageMap
    {
        public Element ExploreMenu => Driver.FindElement(By.CssSelector(".riotbar-left-content"));

        public Element SupportLink => Driver.FindElement(By.CssSelector("[data-riotbar-link-id='support']"));
    }
}
