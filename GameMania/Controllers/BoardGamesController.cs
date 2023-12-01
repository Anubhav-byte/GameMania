using GameMania.DataAcccessLayer.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameMania.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        IBoardGameRepository _boardGamesRepository;
        public BoardGamesController(IBoardGameRepository boardGamesRepository) {
            _boardGamesRepository = boardGamesRepository;
        }

        [ActionName("Suggestions/BasedOnAge")]
        [HttpGet]
        public async Task<IActionResult> GetGameByAge(int age)
        {
            var queryResult = _boardGamesRepository.GetBoardGamesBasedOnAge(age);
            return Ok(queryResult);
        }
    }
}
