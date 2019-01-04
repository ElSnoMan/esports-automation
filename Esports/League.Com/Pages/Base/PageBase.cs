namespace League.Com.Pages.Base
{
    public class PageBase
    {
        public readonly EsportsMenu EsportsMenu;

        public readonly LolMenu LolMenu;

        public PageBase()
        {
            EsportsMenu = new EsportsMenu();
            LolMenu = new LolMenu();
        }
    }
}