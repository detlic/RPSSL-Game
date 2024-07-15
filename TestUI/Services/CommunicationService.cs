using Newtonsoft.Json;
using System.Net;
using TestUI.Models;
using TestUI.Services.IService;
using static TestUI.Utilities.ApiBasic;

namespace TestUI.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CommunicationService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("RPSSL");
                HttpRequestMessage message = new();


                message.RequestUri = new Uri(requestDto.Url);

                HttpResponseMessage? apiResponse = null;
                message.RequestUri = new Uri(requestDto.Url);
                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = client.Send(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
                };
                return dto;
            }
        }
    }
}
