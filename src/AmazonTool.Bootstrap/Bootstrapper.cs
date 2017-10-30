using AmazonTool.Business;
using AmazonTool.Core.Interfaces.Services;
using AmazonTool.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AmazonTool.Core.Logger;
using AmazonTool.Core.Interfaces.Repository;
using AmazonTool.DataAccess.Repositories.Generics;

namespace AmazonTool.Bootstrap
{
    public static class Bootstrapper
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfigurationRoot config)
        {
            // Add framework services.
            services.AddDbContext<AmazonToolContext>(options => options.UseSqlServer(config.GetConnectionString("AmazonContext")));
            var conn = config.GetConnectionString("AmazonContext");
            services.AddSingleton<ILog>(SerligLogger.Create(conn));
            services.AddScoped<IProductQueryService, ProductQueryService>();
            services.AddScoped<ILogQueryService, LogQueryService>();
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
        }
    }
}
