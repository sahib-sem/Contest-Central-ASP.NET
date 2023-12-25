using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Persistence
{
    public class SocialMediaDbContextFactory : IDesignTimeDbContextFactory<ContestCenterDbContext>
    {
        public ContestCenterDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/../WebApi")
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ContestCenterDbContext>();
            var connectionString = configuration.GetConnectionString("SqlConnection");

            builder.UseSqlServer(connectionString);
            builder.EnableSensitiveDataLogging();


            return new ContestCenterDbContext(builder.Options);
        }
    }
}
