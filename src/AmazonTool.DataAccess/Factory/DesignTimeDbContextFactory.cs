using AmazonTool.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonTool.DataAccess.Factory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AmazonToolContext>
    {
        public AmazonToolContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AmazonToolContext>();
            var connectionString = configuration.GetConnectionString("AmazonContext");
            builder.UseSqlServer(connectionString);
            return new AmazonToolContext(builder.Options);
        }
    }
}
