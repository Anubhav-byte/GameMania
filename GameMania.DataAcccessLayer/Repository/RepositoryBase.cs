using GameMania.DataAcccessLayer.Models;

namespace GameMania.DataAcccessLayer.Repository
{
    public class RepositoryBase
    {
        public GameManiaContext _gameManiacontext;
        public RepositoryBase(GameManiaContext gameManiaContext)
        {
            _gameManiacontext = gameManiaContext;
        }
    }
}