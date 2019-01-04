using System;
using League.Com.Pages;

namespace League.Com
{
    public static class Esports
    {
        [ThreadStatic]
        public static LeaguePage League;

        public static void Init()
        {
            League = new LeaguePage();
        }
    }
}
