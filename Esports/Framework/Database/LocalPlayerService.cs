using System.IO;
using Newtonsoft.Json;
using Framework.Model;
using Framework.Interface;

namespace Framework.Database
{
    public class LocalPlayerService : IPlayerService
    {
        public Player GetPlayer()
        {
            return JsonConvert.DeserializeObject<Player>(
                File.ReadAllText(@"../../../../Framework/Data/player.json")
            );
        }
    }
}
