using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using TestUI.Models;
using TestUI.Services.IService;
using static System.Formats.Asn1.AsnWriter;

namespace TestUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChoiceService _choiceService;
        private readonly IGameService _gameService;
        public HomeController(IChoiceService choiceService, IGameService gameService)
        {
            _choiceService = choiceService;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            RemoveScoreSession();

            List<ChoiceDto>? list = new();

            ResponseDto? response = await _choiceService.GetChoices();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ChoiceDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            var model = new ChoiceOptionsDto
            {
                SelectedOptionId = 1,
                Options = list
            };
            return View(model);
        }

        public async Task<IActionResult> AllChoices()
        {
            List<ChoiceDto>? list = new();

            ResponseDto? response = await _choiceService.GetChoices();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ChoiceDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return Json(list);
        }

        public async Task<IActionResult> RandomChoice()
        {
            ChoiceDto? choice = new();

            ResponseDto? response = await _choiceService.GetRandomChoice();

            if (response != null && response.IsSuccess)
            {
                choice = JsonConvert.DeserializeObject<ChoiceDto>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return Json(choice);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(int move)
        {
            PlayResponse playResponse = new();
            SessionDto sessionDto = new();

            ResponseDto? result = await _gameService.PlayGame(move);

            //queue in session
            var sessionData = HttpContext.Session.GetString("Scores");
            var scores = string.IsNullOrEmpty(sessionData) ? new Queue<SessionDto>() : JsonConvert.DeserializeObject<Queue<SessionDto>>(sessionData);

            if (result != null && result.IsSuccess)
            {
            
                playResponse = JsonConvert.DeserializeObject<PlayResponse>(Convert.ToString(result.Result));

                sessionDto.Player = playResponse.Moves[0].Player;
                sessionDto.PlayerMove = playResponse.Moves[0].Move;
                sessionDto.Computer = playResponse.Moves[1].Player;
                sessionDto.ComputerMove = playResponse.Moves[1].Move;
                sessionDto.Result = playResponse.Result;

                if(scores.Count >= 10)
                {
                    scores.Dequeue();
                }
                scores.Enqueue(sessionDto);
                var serializedData = JsonConvert.SerializeObject(playResponse);
                HttpContext.Session.SetString("Scores", JsonConvert.SerializeObject(scores));
            }
            else
            {
                TempData["error"] = result?.Message;
            }
            var singleGameAndScoreResponse = new
            {
                SingleGameResult = playResponse,
                ScoreResponse = scores
            };
            return Json(singleGameAndScoreResponse);
        }

        public void RemoveScoreSession()
        {
            var sessionData = HttpContext.Session.GetString("Scores");
            if (!string.IsNullOrEmpty(sessionData))
            {
                HttpContext.Session.Remove("Scores");
            }
        }
    }
}
