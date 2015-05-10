using System.Collections.Generic;
using System.Threading.Tasks;
using hackathon.droid.Models.Cards;

namespace hackathon.droid.Services.Interface
{
    public interface IGamePlayService
    {
        Task<GamePlayRoot> GetGamePlay();
    }
}
