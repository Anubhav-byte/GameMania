using GameMania.DataAcccessLayer.Infrastructure;
using GameMania.DataAcccessLayer.Models;
using GameMania.DataAcccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMania.DataAcccessLayer.Repository
{
    public class BoardGamesRepository : RepositoryBase, IBoardGameRepository
    {
        public BoardGamesRepository(GameManiaContext gameManiaContext) : base(gameManiaContext)
        {
        }

        public async Task<List<BoardGame>> GetBoardGamesBasedOnAge(int age)
        {
            try
            {
                var result = (from BoardGames in _gameManiacontext.BoardGames 
                                     where BoardGames.MinAge == age select BoardGames).ToList();

                if (result == null)
                    return null;
                return result;

            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
