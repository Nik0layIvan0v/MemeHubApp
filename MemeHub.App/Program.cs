namespace MemeHub.App
{
    using MemeHub.Database;
    using MemeHub.Database.Models;
    using MemeHub.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MemeHubDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDefaultIdentity<User>(options =>
            {
                //Just to make eazy the development
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

            })
             .AddEntityFrameworkStores<MemeHubDbContext>();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScopedServices();
            builder.Services.AddTransientServices();
            builder.Services.AddSingletonServices();

            WebApplication app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                   .UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error")
                   .UseHsts();
            }

            app.ApplyMigrations()
               .UseHttpsRedirection()
               .UseStaticFiles()
               .UseRouting();

            app.UseAuthentication()
               .UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                    name: "Areas",
                    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.Run();
        }
    }
}
