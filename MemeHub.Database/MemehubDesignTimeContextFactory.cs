namespace MemeHub.Database
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class MemehubDesignTimeContextFactory : IDesignTimeDbContextFactory<MemeHubDbContext>
    {
        public MemeHubDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) //TODO: Find absolute path to Memehub.App/appsettins.json by using system.io
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MemeHubDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new MemeHubDbContext(optionsBuilder.Options);
        }
    }
}
