using Domain.Interfaces;
using Infraestructure.EntityFramework.Context;
using Infraestructure.Repositories;
using Infraestructure.Repositories.AzureStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure;
public static class DependencyInjection
{
    public static IServiceCollection AddDataDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddTransient<IDishRepository, DishRepository>();
        services.AddTransient<IAzureStorageRepository, AzureStorageRepository>();

        services.AddDbContext<IDishDbContext, DishDbContext>(opt =>
        {
            //opt.UseSqlServer(configuration.GetConnectionString("AppConnection"));
            opt.UseSqlServer(configuration.GetConnectionString("AppConnection"), b =>
                b.MigrationsAssembly(typeof(DishDbContext).Assembly.FullName));
        });
        return services;
    }
}