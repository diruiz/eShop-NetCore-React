using Amazon.S3;
using eShop.Infrastructure.S3;
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

        var awsOptions = configuration.GetAWSOptions(); // Access key and secret should be in a vault service (AWS Key Management Service) or use AWS IAM
        awsOptions.Credentials = new Amazon.Runtime.BasicAWSCredentials(configuration["AWS:AccessKey"], configuration["AWS:SecretKey"]);
        services.AddDefaultAWSOptions(awsOptions);
        services.AddAWSService<IAmazonS3>();
        services.AddScoped<IS3Bucket, S3Bucket>();

        return services;
    }
}