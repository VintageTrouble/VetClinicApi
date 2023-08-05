using Mapster;

using VetClinicApi.Contracts.AnimalContracts;
using VetClinicApi.Contracts.AnimalTypeContracts;
using VetClinicApi.Core.Entities;

namespace VetClinicApi.API.Common.Mappings;

public class AnimalMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Animal, AnimalResponse>();
        config.NewConfig<CreateAnimalRequest, Animal>();
        config.NewConfig<UpdateAnimalRequest, Animal>();
        config.NewConfig<AnimalType, AnimalTypeResponse>();
    }
}
