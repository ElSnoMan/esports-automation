using System;
using System.IO;
using Newtonsoft.Json;

namespace Framework
{
    public static class FW
    {
        public static void Init()
        {
            if (_configuration == null)
            {
                var jsonString = File.ReadAllText(WORKSPACE_DIRECTORY + "/config.json");
                _configuration = JsonConvert.DeserializeObject<Config>(jsonString);
            }
        }

        public static Config Config => _configuration ?? throw new Exception("_configuration null. Call Init() first.");

        public static string WORKSPACE_DIRECTORY => Path.GetFullPath(@"../../../../");

        private static Config _configuration;
    }

    public class Config
    {
        public DriverSettings Driver { get; set; }
    }

    public class DriverSettings
    {
        public string Browser { get; set; }

        public string Type { get; set; }

        public int Wait { get; set; }
    }
}
