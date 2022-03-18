using BlogSample.Core.Contracts.Data.Repository;
using BlogSample.Core.Contracts.Service;
using BlogSample.Core.Domain;
using BlogSample.Data;
using BlogSample.Data.Repository;
using BlogSample.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSample.Modules
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            return services;
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services
                .AddScoped<IBlogService, BlogService>();
            return services;
        }
    }
}
