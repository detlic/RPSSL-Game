using static TestUI.Utilities.ApiBasic;

namespace TestUI.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; } = string.Empty;
        public object Data { get; set; }
    }
}
