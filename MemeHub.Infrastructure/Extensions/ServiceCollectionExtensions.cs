namespace MemeHub.Infrastructure.Extensions
{
    using MemeHub.Services.CategoryService;
    using MemeHub.Services.CommentService;
    using MemeHub.Services.LabelService;
    using MemeHub.Services.LikeService;
    using MemeHub.Services.MemeService;
    using Microsoft.AspNetCore.Routing;
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
            collection.AddTransient<IMemeService, MemeService>();
            collection.AddTransient<ILabelService, LabelService>();
            collection.AddTransient<ICategoryService, CategoryService>();
            collection.AddTransient<ICommentService, CommentService>();
            collection.AddTransient<ILikeService, LikeService>();
            return collection;
        }

        public static IServiceCollection AddSingletonServices(this IServiceCollection collection)
        {
            //Register here all singleton services here
            return collection;
        }

        public static IServiceCollection ApplyRouteConfigurations(this IServiceCollection collection)
        {
            collection.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
            });

            return collection;
        }
    }
}
