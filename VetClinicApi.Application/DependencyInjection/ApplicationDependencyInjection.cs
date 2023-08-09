﻿using Microsoft.Extensions.DependencyInjection;

using VetClinicApi.Application.Services.AnimalHandling;
using VetClinicApi.Application.Services.CustomerHandlig;
using VetClinicApi.Application.Services.ExceptionHandling;
using VetClinicApi.Application.Services.PriceListHandling;

namespace VetClinicApi.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IExceptionHandlerService, ExceptionHandlerService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IAnimalService, AnimalService>();
        services.AddScoped<IPriceListService, PriceListService>();
        return services;
    }
}
