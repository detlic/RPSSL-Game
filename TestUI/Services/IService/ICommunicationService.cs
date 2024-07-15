using TestUI.Models;

namespace TestUI.Services.IService
{
    public interface ICommunicationService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
