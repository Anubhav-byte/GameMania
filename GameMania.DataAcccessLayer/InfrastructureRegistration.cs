using GameMania.DataAcccessLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameMania.DataAcccessLayer.Infrastructure;
using GameMania.DataAcccessLayer.Repository;
using StackExchange.Redis;

namespace GameMania.DataAcccessLayer
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<GameManiaContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("LocalDBConnectionStrings")));
            services.AddSingleton<IDatabase>(confg =>
            {
                IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnectionString"));
                return multiplexer.GetDatabase();
            });
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IBoardGameRepository, BoardGamesRepository>();
            
            return services;
        }
    }
}
