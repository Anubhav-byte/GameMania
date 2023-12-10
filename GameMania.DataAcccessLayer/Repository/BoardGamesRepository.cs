using GameMania.DataAcccessLayer.Infrastructure;
using GameMania.DataAcccessLayer.Models;
using GameMania.DataAcccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMania.DataAcccessLayer.Repository
{
    public class BoardGamesRepository : RepositoryBase, IBoardGameRepository
    {
        public BoardGamesRepository(GameManiaContext gameManiaContext,ICacheService cacheService) : base(gameManiaContext,cacheService)
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

        public async Task<IEnumerable<BoardGame>> GetAllBoardGames()
        {
            try
            {
                var cacheData = _cacheService.GetData<IEnumerable<BoardGame>>("BoardGames");

                
                if (cacheData != null)
                {
                    Console.WriteLine("Cached Data");
                    return cacheData;
                }
                var queryResult = (from BoardGames in _gameManiacontext.BoardGames
                              select BoardGames).ToList();
                if (queryResult != null)
                {
                    bool isSet = _cacheService.SetData("BoardGames", queryResult, DateTimeOffset.Now.AddMinutes(5.0));
                    return queryResult;
                }
               
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
