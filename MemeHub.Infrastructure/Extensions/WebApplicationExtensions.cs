namespace MemeHub.Infrastructure.Extensions
{
    using MemeHub.Database;
    using MemeHub.Seeder.AdministratorSeeder;
    using MemeHub.Seeder.CategoriesSeeder;
    using MemeHub.Services.CategoryService;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class WebApplicationExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder builder)
        {
            IServiceScope scope = builder.ApplicationServices.CreateScope();
            MemeHubDbContext memeDbContext = scope.ServiceProvider.GetRequiredService<MemeHubDbContext>();
            //memeDbContext.Database.EnsureDeleted(); /* Delete database before migration USE ONLY UNTIL is implemented correctly! */
            memeDbContext.Database.Migrate();
            return builder;
        }

        public static IApplicationBuilder AddDefaultAdministrator(this IApplicationBuilder builder)
        {
            var adminiStratorSeeder = new DefaultAdministratorSeeder();
            IServiceScope scope = builder.ApplicationServices.CreateScope();
            adminiStratorSeeder.SeedDefaultAdministrator(scope.ServiceProvider);
            return builder;
        }

        public static IApplicationBuilder SeedDefaultCategories(this IApplicationBuilder builder)
        {
            IServiceScope scope = builder.ApplicationServices.CreateScope();
            var categoryService = scope.ServiceProvider.GetRequiredService<ICategoryService>();
            ICategorySeeder categorySeeder = new CategorySeeder(categoryService);
            categorySeeder.SeedDefaultCategories();
            return builder;
        }
    }
}
