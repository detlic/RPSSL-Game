using TestUI.Models;

namespace TestUI.Services.IService
{
    public interface IGameService
    {
        Task<ResponseDto?> PlayGame(int move);
    }
}
