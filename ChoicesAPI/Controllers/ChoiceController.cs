using ChoicesAPI.Model;
using ChoicesAPI.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChoicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoiceController : ControllerBase
    {
        private readonly IChoice _choice;
        private ResponseDto _response;
        public ChoiceController(IChoice choice)
        {
            _choice = choice;
            _response = new ResponseDto();
        }
        [HttpGet]
        [Route("GetChoices")]
        public ResponseDto GetChoices()
        {
            try
            {
                _response.Result = _choice.GetChoices();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet]
        [Route("GetChoice")]
        public ResponseDto GetChoice()
        {
            try
            {
                _response.Result = _choice.GetRandomChoice();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
