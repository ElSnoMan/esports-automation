using System.Linq;
using Framework.Selenium;
using OpenQA.Selenium;

namespace League.Com.Pages.Base
{
	public class LolMenu
	{
		public readonly LolMenuMap Map;

		public LolMenu()
		{
			Map = new LolMenuMap();
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
	}

    public class LolMenuMap
    {
        public Element LolHomePageLink => Driver.FindElement(By.XPath("(//a[contains(@href, 'https://na.leagueoflegends.com/en/')]"));
        public Element NewsPageLink => Driver.FindElement(By.XPath("(//a[contains(@href, 'https://na.leagueoflegends.com/en/news/')]"));
        public Element GamePageLink => Driver.FindElement(By.XPath("(//a[contains(@href, 'http://gameinfo.na.leagueoflegends.com/en/game-info/')]"));
        public Element UniversePageLink => Driver.FindElement(By.XPath("(//a[contains(@href, 'http://universe.leagueoflegends.com/en_US/')]"));
        public Element NexusPageLink => Driver.FindElement(By.XPath("(//a[contains(@href, 'http://nexus.leagueoflegends.com/')]"));
        public Element ESportsPageLink => Driver.FindElement(By.XPath("(//a[contains(@href, 'http://www.lolesports.com/en_US')]"));
        public Element CommunityPageLink => Driver.FindElement(By.XPath("(//a[contains(@href, 'http://boards.na.leagueoflegends.com/en/')]"));
        public Element SupportPageLink => Driver.FindElement(By.XPath("(//a[contains(@href, 'https://support.riotgames.com/hc/en-us')]"));
        public Element MerchandisePageLink => Driver.FindElement(By.XPath("(//a[contains(@href, 'https://na.merch.riotgames.com/en/')]"));
        public Element RegionLanguageDropdown => Driver.FindElement(By.CssSelector("div[id *='riotbar-locale-switch-trigger']"));
        public Element RegionDropdown => Driver.FindElement(By.CssSelector("div[id *='riotbar-region-dropdown-trigger']"));
        public Element Region(string region) => Driver.FindElements(By.CssSelector("li.riotbar-region-option")).FirstOrDefault(r => r.Text == region);
        public Element Language(string language) => Driver.FindElements(By.CssSelector("//a[contains(text(), language)]")).FirstOrDefault(l => l.Text == language);
    }
}