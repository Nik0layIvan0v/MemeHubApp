namespace MemeHub.Infrastructure.Extensions
{
    using MemeHub.Database;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class WebApplicationExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder builder)
        {
            IServiceScope scope = builder.ApplicationServices.CreateScope();
            MemeHubDbContext memeDbContext = scope.ServiceProvider.GetRequiredService<MemeHubDbContext>();
            memeDbContext.Database.EnsureDeleted(); /* Delete database before migration USE ONLY UNTIL is implemented correctly! */
            memeDbContext.Database.Migrate();
            return builder;
        }
    }
}
