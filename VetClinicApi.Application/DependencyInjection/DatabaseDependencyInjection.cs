using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using VetClinicApi.Core.Entities;
using VetClinicApi.Database;
using VetClinicApi.Database.Repositories;

namespace VetClinicApi.Application.DependencyInjection;

public static class DatabaseDependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextFactory<VetClinicContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IRepository<Animal>, BaseRepository<Animal>>();
        services.AddScoped<IRepository<AnimalType>, BaseRepository<AnimalType>>();
        services.AddScoped<IRepository<Room>, BaseRepository<Room>>();
        services.AddScoped<IRepository<Visit>, BaseRepository<Visit>>();
        services.AddScoped<IRepository<ProvidedService>, BaseRepository<ProvidedService>>();

        return services;
    }
}
