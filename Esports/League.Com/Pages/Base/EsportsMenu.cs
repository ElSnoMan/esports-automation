using Framework.Selenium;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class EsportsMenu
    {
        public Element StandingsLink => Driver.FindElement(By.XPath("(//a[contains(text(), 'Standings')])[last()]"), "STANDINGS nav link");
    }
}
