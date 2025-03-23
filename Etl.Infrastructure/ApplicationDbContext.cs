using Etl.Domain.Entities.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Etl.Infrastructure
{
    public class ApplicationDbContext(IConfiguration configuration) : DbContext
    {
        private const string DATABASE = "Database";

        public DbSet<University> Universities => Set<University>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(DATABASE));
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        private ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
