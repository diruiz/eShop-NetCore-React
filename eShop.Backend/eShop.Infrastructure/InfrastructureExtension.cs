using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Infrastructure;

public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructureDependencyInjectionServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "Redis_eShop_";
        });
        return services;
    }
}