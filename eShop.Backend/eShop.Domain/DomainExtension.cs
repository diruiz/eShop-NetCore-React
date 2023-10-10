using eShop.Domain.Services.Implementation;
using eShop.Domain.Services.Interfaces;
using eShop.Persistence.Context;
using eShop.Persistence.Repository.Implementation;
using eShop.Persistence.Repository.Interface;
using eShop.Persistence.UnitOfWork.Implementation;
using eShop.Persistence.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.Domain
{
    public static class DomainExtension
    {
        public static IServiceCollection AddDomainDependencyInjectionServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EShopDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("StoreConnection"));
            });

            #region Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Services
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}