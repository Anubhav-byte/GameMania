using GameMania.DataAcccessLayer.Infrastructure;
using GameMania.DataAcccessLayer.Models;

namespace GameMania.DataAcccessLayer.Repository
{
    public class RepositoryBase
    {
        public GameManiaContext _gameManiacontext;
        public ICacheService _cacheService;
        public RepositoryBase(GameManiaContext gameManiaContext,ICacheService cacheService)
        {
            _gameManiacontext = gameManiaContext;
            _cacheService = cacheService;
        }
    }
}