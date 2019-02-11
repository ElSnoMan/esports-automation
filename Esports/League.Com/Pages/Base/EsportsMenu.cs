using Framework.Selenium;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class EsportsMenu
    {
        public Element IssuesDialog => Driver.FindElement(By.CssSelector("a.message-text"));

        public Element IssuesButton => Driver.FindElement(By.Id("riotbar-service-status-icon"));

        public Element StandingsLink => Driver.FindElement(By.XPath("(//a[contains(text(), 'Standings')])[last()]"), "STANDINGS nav link");
    }
}
