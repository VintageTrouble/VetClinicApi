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
        services.AddScoped<IAnimalRepository, AnimalRepository>();
        services.AddScoped<IAbstractRepository<AnimalType>, AnimalTypeRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IProvidedServiceRepository, ProvidedServiceRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();

        return services;
    }
}
