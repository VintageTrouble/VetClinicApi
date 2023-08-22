using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;
using VetClinicApi.Database.Repositories.Base;

namespace VetClinicApi.Application.Services.ProvidedServiceHandling;

public class ProvidedServiceService : IProvidedServiceService
{
    private readonly IRepository<ProvidedService> _providedServiceRepository;

    public ProvidedServiceService(IRepository<ProvidedService> providedServiceRepository)
    {
        _providedServiceRepository = providedServiceRepository;
    }

    public async Task<ProvidedService> CreateProvidedService(ProvidedService? providedService)
    {
        if (providedService == null)
            throw new ArgumentNullException(nameof(providedService), "ProvidedService can't be null.");

        return await _providedServiceRepository.Add(providedService);
    }

    public async Task DeleteProvidedService(int id)
    {
        try
        {
            await _providedServiceRepository.Delete(id);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new EntityNotFoundException(id, "ProvidedService");
        }
    }

    public async Task<IEnumerable<ProvidedService>> GetAllProvidedServices()
    {
        return await _providedServiceRepository.GetAll();
    }

    public async Task<ProvidedService> UpdateProvidedService(ProvidedService? providedService)
    {
        if (providedService == null)
            throw new ArgumentNullException(nameof(providedService), "ProvidedService can't be null.");

        try
        {
            return await _providedServiceRepository.Update(providedService);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new EntityNotFoundException(providedService.Id, "ProvidedService");
        }

    }
}
