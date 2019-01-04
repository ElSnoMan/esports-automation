using Framework.Selenium;
using League.Com.Pages.Base;

namespace League.Com.Pages
{
    public class LolEsportsHomePage : PageBase
	{
		public readonly LolEsportsHomePageMap Map;

		public LolEsportsHomePage()
		{
			Map = new LolEsportsHomePageMap();
		}

		public void Goto()
		{
			EsportsMenu.GotoHome();
		}

		public void WaitForPageLoad()
		{
			Driver.Wait.Until((drvr) => EsportsMenu.Map.HomeLink.Displayed);
		}
	}

	public class LolEsportsHomePageMap
	{

	}
}