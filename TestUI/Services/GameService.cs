using TestUI.Models;
using TestUI.Services.IService;
using TestUI.Utilities;

namespace TestUI.Services
{
    public class GameService : IGameService
    {
        private readonly ICommunicationService _communicationService;
        public GameService(ICommunicationService communicationService)
        {
            _communicationService = communicationService;
        }
        public async Task<ResponseDto?> PlayGame(int move)
        {
            return await _communicationService.SendAsync(new RequestDto()
            {
                ApiType = ApiBasic.ApiType.POST,
                Data = move,
                Url = ApiBasic.PlayAPIBase + "/api/game/" + move
            });
        }
        
    }
}
