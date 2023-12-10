using GameMania.DataAcccessLayer.Infrastructure;
using GameMania.DataAcccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameMania.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        IBoardGameRepository _boardGamesRepository;
        ICacheService _cacheService;
        public BoardGamesController(IBoardGameRepository boardGamesRepository,ICacheService cacheService) {
            _boardGamesRepository = boardGamesRepository;
            _cacheService = cacheService;
        }

        [ActionName("Suggestions/BasedOnAge")]
        [HttpGet]
        public async Task<IActionResult> GetGameByAge(int age)
        {
            var queryResult = _boardGamesRepository.GetBoardGamesBasedOnAge(age);
            return Ok(queryResult);
        }

        [ActionName("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAllBoardGames()
        {
            try
            {
                var queryResult = await _boardGamesRepository.GetAllBoardGames();
                if(queryResult != null)
                {
                    return Ok(queryResult);
                }           
                return Ok("Data Not Found");
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
        }
    }
}
