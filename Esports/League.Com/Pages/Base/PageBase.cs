namespace League.Com.Pages.Base
{
    public class PageBase
    {
        public readonly EsportsMenu EsportsMenu;

        public readonly WatchMenu WatchMenu;

        public PageBase()
        {
            EsportsMenu = new EsportsMenu();
            WatchMenu = new WatchMenu();
        }
    }
}
