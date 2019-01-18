using System.Threading;
using Framework.Selenium;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class TicketsPage
    {
        public readonly TicketsPageMap Map;

        public TicketsPage()
        {
            Map = new TicketsPageMap();
        }

        public void Goto()
        {
            Driver.Wait.Until(driver => Map.TicketsLink.Displayed);
            Map.TicketsLink.Click();
        }

        public void ClickFirstDate()
        {
            Map.FirstDate.Click();
        }

        public bool SoldOut()
        {
            Driver.Wait.Until(driver => Map.TicketContainer.Displayed);

            if (Map.SoldOut.Displayed && !Map.AddToCartButton.Enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class TicketsPageMap
    {
        public Element TicketsLink => Driver.FindElement(By.XPath("(//a[contains(text(), 'Tickets')])[last()]"));
        public Element FirstDate => Driver.FindElement(By.CssSelector(".squadup-checkout-event-box"));

        public Element TicketContainer => Driver.FindElement(By.CssSelector(".form-group"));
        public Element SoldOut => Driver.FindElement(By.XPath("//*[text()='Sold Out!']"));
        public Element AddToCartButton => Driver.FindElement(By.XPath("//span[text()='Add to Cart']/parent::*"));
    }
}
