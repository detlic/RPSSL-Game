using TestUI.Models;

namespace TestUI.Services.IService
{
    public interface IChoiceService
    {
        Task<ResponseDto?> GetChoices();
        Task<ResponseDto?> GetRandomChoice();
    }
}
