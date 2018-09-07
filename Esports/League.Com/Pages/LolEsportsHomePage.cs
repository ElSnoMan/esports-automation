using System;
using League.Com.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace League.Com.Pages
{
	public class LolEsportsHomePage : PageBase
	{
		readonly IWebDriver _driver;
		readonly WebDriverWait _wait;
		public readonly LolEsportsHomePageMap Map;

		public LolEsportsHomePage(IWebDriver driver, WebDriverWait wait) : base(driver)
		{
			_driver = driver;
			_wait = wait;
			Map = new LolEsportsHomePageMap(driver);
		}

		public void Goto()
		{
			EsportsMenu.GotoHome();
		}


		public void WaitForPageLoad()
		{
			_wait.Until((drvr) => EsportsMenu.Map.HomeLink.Displayed);
		}


	}
	public class LolEsportsHomePageMap

	{
		readonly IWebDriver _driver;

		public LolEsportsHomePageMap(IWebDriver driver)
		{
			_driver = driver;
		}
	}
}

