using GameMania.DataAcccessLayer.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMania.DataAcccessLayer.Repository
{
    public class CacheService : ICacheService
    {
        private IDatabase _cacheDatabase;

        public CacheService(IDatabase cacheDatabase)
        {
            _cacheDatabase = cacheDatabase;
        }
        public T? GetData<T>(string key)
        {

            try
            {
                var value = _cacheDatabase.StringGet(key);
                if (!String.IsNullOrEmpty(value))
                {
                    Console.WriteLine();
                    var jsonResult = JObject.Parse(value);
                    var jsonBoardGames = jsonResult["Result"];

                    return JsonConvert.DeserializeObject<T>(jsonBoardGames.ToString());
                }
                return default;
            }
            catch (Exception ex)
            {

                return default;
            }
            
            
        }

        public object RemoveData(string key)
        {
            throw new NotImplementedException();
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            bool isSet = _cacheDatabase.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
            
        }
    }
}
