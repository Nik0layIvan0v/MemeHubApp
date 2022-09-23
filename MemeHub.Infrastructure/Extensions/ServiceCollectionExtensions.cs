namespace MemeHub.Infrastructure.Extensions
{
    using MemeHub.Database;
    using MemeHub.Services.LabelService;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection collection)
        {
            //Register here all scoped services here
            return collection;
        }

        public static IServiceCollection AddTransientServices(this IServiceCollection collection)
        {
            //Register here all transient services here
            collection.AddTransient<ILabelService,LabelService>();
            collection.AddTransient<IMemeHubDbContext, MemeHubDbContext>();
            return collection;
        }

        public static IServiceCollection AddSingletonServices(this IServiceCollection collection)
        {
            //Register here all singleton services here
            return collection;
        }
    }
}
