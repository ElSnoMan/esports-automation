using System;
using System.IO;

namespace Framework.Settings
{
    public static class Config
    {
        public static string DRIVERPATH =
            Path.Combine(Environment.CurrentDirectory, PlatformDriver);

        static string PlatformDriver
        {
            get
            {
                if (Environment.OSVersion.Platform.ToString().Contains("Win"))
                {
                    return @"tests\_drivers_win";
                }

                return @"tests\_drivers_mac";
            }
        }
    }
}
