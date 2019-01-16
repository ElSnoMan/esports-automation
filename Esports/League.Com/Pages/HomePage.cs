using Framework.Selenium;
using League.Com.Pages.Base;
using OpenQA.Selenium;

namespace League.Com.Pages
{
    public class HomePage : PageBase
	{
		public readonly HomePageMap Map;

		public HomePage()
		{
			Map = new HomePageMap();
		}
	}

	public class HomePageMap
	{
        public Element PlayNowSignupButton => Driver.FindElement(By.CssSelector("[data-riotbar-link-id='signup']"));
	}
}
