namespace MemeHub.Seeder.AdministratorSeeder
{
    using MemeHub.Database.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.IO;

    public class DefaultAdministratorSeeder : IAdministratorSeeder
    {
        public async void SeedDefaultAdministrator(IServiceProvider serviceProvider)
        {
            var adminConfiguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var roleName = adminConfiguration.GetRequiredSection("Administrator:Rolename").Value;
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (await roleManager.RoleExistsAsync(roleName) == true)
            {
                return;
            }

            IdentityRole role = new IdentityRole()
            {
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
            };

            await roleManager.CreateAsync(role);
            var email = adminConfiguration.GetRequiredSection("Administrator:Email").Value;
            var username = adminConfiguration.GetRequiredSection("Administrator:Username").Value;
            var administrator = new User()
            {
                Email = email,
                UserName = username,
                LockoutEnabled = false
            };

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var password = adminConfiguration.GetRequiredSection("Administrator:Password").Value;
            await userManager.CreateAsync(administrator, password);
            await userManager.AddToRoleAsync(administrator, role.Name);
        }
    }
}
