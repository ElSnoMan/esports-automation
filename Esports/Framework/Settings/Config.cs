using System;
using System.IO;

namespace Framework.Settings
{
    public static class Config
    {
        public static string DRIVER_PATH = Path.Combine(Directory.GetCurrentDirectory(), PlatformDriver);

        public static Uri DOCKER_GRID_HUB_URI = new Uri("http://localhost:4444/wd/hub");

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