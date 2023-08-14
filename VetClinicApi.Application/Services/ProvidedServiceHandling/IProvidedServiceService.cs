using VetClinicApi.Core.Entities;

namespace VetClinicApi.Application.Services.ProvidedServiceHandling;

public interface IProvidedServiceService
{
    Task<IEnumerable<ProvidedService>> GetAllProvidedServices();
    Task<ProvidedService>? CreateProvidedService(ProvidedService providedService);
    Task DeleteProvidedService(int id);
    Task<ProvidedService>? UpdateProvidedService(ProvidedService providedService);
}
