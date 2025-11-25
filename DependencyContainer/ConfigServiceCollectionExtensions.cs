using ApplicationService.Services.ProductServices;
using ApplicationService.Services.ProductServices.Contract;
using Domain.Aggregates.UserManagementAggregates;
using EfCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RepositoryDesignPattern.Contracts;
using RepositoryDesignPattern.Services;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigServiceCollectionExtensions
{
    public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
    {
       
        services.AddDbContext<SecurityWebAPIContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("SecurityWebAPIConnectionString"));
        });


        services.AddIdentity<User, Role>().AddEntityFrameworkStores<SecurityWebAPIContext>();
        services.Configure<IdentityOptions>(c =>
        {
            c.Password.RequireDigit = false;
            c.Password.RequireNonAlphanumeric = false;
            c.Password.RequiredLength = 3;
            c.Password.RequireUppercase = false;
            c.Password.RequireLowercase = false;
        });
        return services;
    }

    public static IServiceCollection AddDependencyGroup(
         this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
