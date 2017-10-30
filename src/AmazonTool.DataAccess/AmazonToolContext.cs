using AmazonTool.Core.Entities.Application;
using Microsoft.EntityFrameworkCore;

namespace AmazonTool.DataAccess
{
    public class AmazonToolContext: DbContext
    {
        DbSet<Log> Logs { get; set; }

        public AmazonToolContext(DbContextOptions<AmazonToolContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV12;Database=AmazonToolContext;Trusted_Connection=True;");
        }
    }
}
