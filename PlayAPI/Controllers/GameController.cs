using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayAPI.Model;
using PlayAPI.Utilities;

namespace PlayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IPlayGame _playGame;
        private ResponseDto _response;
        public GameController(IPlayGame playGame)
        {
            _playGame = playGame;
            _response = new ResponseDto();
        }

        [HttpPost]
        [Route("{move:int}")]
        public ResponseDto Game(int move)
        {
            try 
            {
                _response.Result = _playGame.DecideWinner(move);
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
