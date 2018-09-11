using System;
using System.Linq;
using OpenQA.Selenium;

namespace League.Com.Pages.Base
{
	public class LolMenu
	{
		readonly IWebDriver _driver;
		public readonly LolMenuMap Map;

		public LolMenu(IWebDriver driver, OpenQA.Selenium.Support.UI.WebDriverWait wait)
		{
			_driver = driver;
			Map = new LolMenuMap(driver);
		}


		public void GotoLolHomePage()
		{
			Map.LolHomePageLink.Click();
		}

		public void GotoNewsPage()
		{
			Map.NewsPageLink.Click();
		}

		public void GotoGamePage()
		{
			Map.GamePageLink.Click();
		}

		public void GotoUniversePage()
		{
			Map.UniversePageLink.Click();
		}

		public void GotoNexusPage()
		{
			Map.UniversePageLink.Click();
		}

		public void GotoESportsPage()
		{
			Map.ESportsPageLink.Click();
		}

		public void GotoCommunityPage()
		{
			Map.CommunityPageLink.Click();
		}

		public void GotoSupportPage()
		{
			Map.SupportPageLink.Click();
		}

		public void GotoMerchandisePage()
		{
			Map.MerchandisePageLink.Click();
		}
        
		public void SelectLanguageByRegion(string region, string language)
		{
			Map.RegionLanguageDropdown.Click();
			Map.RegionDropdown.Click();
			Map.Region(region).Click();
			Map.Language(language).Click();
            
		}


		public class LolMenuMap
		{
			readonly IWebDriver _driver;

			public LolMenuMap(IWebDriver driver)
			{
				_driver = driver;
			}
			public IWebElement LolHomePageLink => _driver.FindElements(By.XPath("(//a[contains(@href, 'https://na.leagueoflegends.com/en/')]"))[0];
			public IWebElement NewsPageLink => _driver.FindElements(By.XPath("(//a[contains(@href, 'https://na.leagueoflegends.com/en/news/')]"))[0];
			public IWebElement GamePageLink => _driver.FindElements(By.XPath("(//a[contains(@href, 'http://gameinfo.na.leagueoflegends.com/en/game-info/')]"))[1];
			public IWebElement UniversePageLink => _driver.FindElements(By.XPath("(//a[contains(@href, 'http://universe.leagueoflegends.com/en_US/')]"))[1];
			public IWebElement NexusPageLink => _driver.FindElements(By.XPath("(//a[contains(@href, 'http://nexus.leagueoflegends.com/')]"))[1];
			public IWebElement ESportsPageLink => _driver.FindElements(By.XPath("(//a[contains(@href, 'http://www.lolesports.com/en_US')]"))[1];
			public IWebElement CommunityPageLink => _driver.FindElements(By.XPath("(//a[contains(@href, 'http://boards.na.leagueoflegends.com/en/')]"))[1];
			public IWebElement SupportPageLink => _driver.FindElements(By.XPath("(//a[contains(@href, 'https://support.riotgames.com/hc/en-us')]"))[1];
			public IWebElement MerchandisePageLink => _driver.FindElements(By.XPath("(//a[contains(@href, 'https://na.merch.riotgames.com/en/')]"))[1];
			public IWebElement RegionLanguageDropdown => _driver.FindElement(By.CssSelector("div[id *='riotbar-locale-switch-trigger']"));
			public IWebElement RegionDropdown => _driver.FindElement(By.CssSelector("div[id *='riotbar-region-dropdown-trigger']"));
			public IWebElement Region(string region) => _driver.FindElements(By.CssSelector("li.riotbar-region-option")).FirstOrDefault(r => r.Text == region);
			public IWebElement Language(string language) => _driver.FindElements(By.CssSelector("//a[contains(text(), language)]")).FirstOrDefault(l => l.Text == language);
            //Hey Carlos!  Did I do this ^ right?
		}
	}
}