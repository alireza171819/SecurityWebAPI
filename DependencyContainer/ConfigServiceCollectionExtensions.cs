using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigServiceCollectionExtensions
{
    public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
    {
        services.Configure<PositionOptions>(
            config.GetSection(PositionOptions.Position));

        return services;
    }

    public static IServiceCollection AddDependencyGroup(
         this IServiceCollection services)
    {
        services.AddScoped<IMyDependency, MyDependency>();
        services.AddScoped<IMyDependency2, MyDependency2>();

        return services;
    }
}
