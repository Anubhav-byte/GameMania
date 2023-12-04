using GameMania.DataAcccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMania.DataAcccessLayer.Infrastructure
{
    public interface IBoardGameRepository
    {
       Task<List<BoardGame>> GetBoardGamesBasedOnAge(int age);
       Task<List<BoardGame>> GetAllBoardGames();
    }
}
