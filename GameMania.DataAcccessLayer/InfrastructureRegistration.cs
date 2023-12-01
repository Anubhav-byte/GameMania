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

namespace GameMania.DataAcccessLayer
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<GameManiaContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("LocalDBConnectionStrings")));
            services.AddScoped<IBoardGameRepository, BoardGamesRepository>();
            return services;
        }
    }
}
