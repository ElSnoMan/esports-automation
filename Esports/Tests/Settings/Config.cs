using System;
using System.IO;

namespace Tests.Settings
{
    public static class Config
    {
        public static string DRIVERPATH = Path.Combine(Directory.GetCurrentDirectory(), PlatformDriver);

        private static string PlatformDriver
        {
            get
            {
                return Environment.OSVersion.Platform.ToString().Contains("Win")
                    ? "tests/_drivers/windows"
                    : "tests/_drivers/mac";
            }
        }
    }
}