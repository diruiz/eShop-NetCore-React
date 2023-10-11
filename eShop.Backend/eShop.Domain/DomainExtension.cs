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
            #region Contexts
            services.AddDbContext<EShopDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("StoreConnection"));
            });
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Repositories
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<ICatalogBrandRepository, CatalogBrandRepository>();
            services.AddScoped<ICatalogTypeRepository, CatalogTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Services
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IUserService, UserService>();
            #endregion

            return services;
        }
    }
}