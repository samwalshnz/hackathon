using System;
using System.IO;
using System.Threading.Tasks;
using hackathon.droid.Models.Cards;
using hackathon.droid.Services.Interface;
using Newtonsoft.Json;

namespace hackathon.droid.Services.Concrete
{
    public class GamePlayService : IGamePlayService
    {
        public async Task<GamePlayRoot> GetGamePlay()
        {
//            string json;
//            using (var stream = new StreamReader(Asset.))
//            {
//                json = await stream.ReadToEndAsync();
//            }

			string json = string.Empty;


            return string.IsNullOrEmpty(json) ? new GamePlayRoot() : JsonConvert.DeserializeObject<GamePlayRoot>(json);
        }
    }
}
