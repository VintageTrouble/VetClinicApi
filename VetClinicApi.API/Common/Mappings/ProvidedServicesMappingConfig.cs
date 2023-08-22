using Mapster;

using VetClinicApi.Contracts.ProvidedServicesContracts;
using VetClinicApi.Core.Entities;

namespace VetClinicApi.API.Common.Mappings;

public class ProvidedServicesMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ProvidedService, ProvidedServicesResponse>();
        config.NewConfig<CreateProvidedServiceRequest, ProvidedService>();
        config.NewConfig<UpdateProvidedServiceRequest, ProvidedService>();
    }
}
