using System.Linq;
using Framework.Selenium;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class ServiceStatusPage
    {
        public readonly ServiceStatusPageMap Map;

        public ServiceStatusPage()
        {
            Map = new ServiceStatusPageMap();
        }

        public void Goto()
        {
            Driver.Wait.Until(driver => driver.FindElement(By.XPath("(//a[@data-riotbar-link-id='service-status'])[last()]")));
            Map.ServiceStatusLink.Click();
        }

        public bool ServiceOnline(string serviceName) // Game, Client
        {
            var service = Map.Services.First(ser =>
                ser.FindElement(By.CssSelector(".service-name"))
                   .Text == serviceName);

            var status = service.FindElement(By.CssSelector(".status-text"));

            return status.Text == "Online";
        }
    }

    public class ServiceStatusPageMap
    {
        public Element ServiceStatusLink => Driver.FindElement(By.XPath("(//a[@data-riotbar-link-id='service-status'])[last()]"));

        public Elements Services => Driver.FindElements(By.CssSelector(".service-info"));
    }
}
