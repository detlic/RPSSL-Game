using TestUI.Models;
using TestUI.Services.IService;
using TestUI.Utilities;

namespace TestUI.Services
{
    public class ChoiceService : IChoiceService
    {
        private readonly ICommunicationService _communicationService;
        public ChoiceService(ICommunicationService communicationService)
        {
            _communicationService = communicationService;
        }
        public async Task<ResponseDto?> GetChoices()
        {
            return await _communicationService.SendAsync(new RequestDto()
            {
                ApiType = ApiBasic.ApiType.GET,
                Url = ApiBasic.ChoiceAPIBase + "/api/choice/getchoices",
            });
        }

        public async Task<ResponseDto?> GetRandomChoice()
        {
            return await _communicationService.SendAsync(new RequestDto()
            {
                ApiType = ApiBasic.ApiType.GET,
                Url = ApiBasic.ChoiceAPIBase + "/api/choice/getchoice",
            });
        }
    }
}
