namespace MemeHub.Seeder.AdministratorSeeder
{
    using Microsoft.Extensions.DependencyInjection;

    public interface IAdministratorSeeder
    {
        void SeedDefaultAdministrator(IServiceProvider serviceProvider);
    }
}
