using MapsterMapper;

using VetClinicApi.Contracts.AnimalContracts;
using VetClinicApi.Contracts.AnimalTypeContracts;
using VetClinicApi.Core.Entities;

using Xunit;

namespace VetClinicApi.API.Tests.Common.Mappings;

public class AnimalMappingConfig_Test
{
    private readonly IMapper _mapper;

    public AnimalMappingConfig_Test()
    {
        _mapper = AddMapsterForUnitTests.GetMapper();
    }

    [Fact]
    public void Map_AnimalToAnimalResponse_Test()
    {
        var animal = new Animal
        {
            Id = 1,
            Name = "Ben",
            CustomerId = 1,
            AnimalTypeId = 1,
            Breed = "American Curl",
            BirthDate = new DateTime(2020, 01, 01),
            IsVaccinated = true,
            CreationDate = new DateTime(2021, 04, 03),
            LastEditDate = new DateTime(2021, 04, 03)
        };

        var result = _mapper.Map<AnimalResponse>(animal);

        Assert.Equal(animal.Id, result.Id);
        Assert.Equal(animal.Name, result.Name);
        Assert.Equal(animal.CustomerId, result.CustomerId);
        Assert.Equal(animal.BirthDate, result.BirthDate);
        Assert.Equal(animal.Breed, result.Breed);
        Assert.Equal(animal.IsVaccinated, result.IsVaccinated);
    }

    [Fact]
    public void Map_CreateAnimalRequestToAnimal_Test()
    {
        var animal = new CreateAnimalRequest(
            "Ben",
            1,
            1,
            "American Curl",
            new DateTime (2020, 03, 03),
            true);

        var result = _mapper.Map<Animal>(animal);

        Assert.Equal(default, result.Id);
        Assert.Equal(animal.Name, result.Name);
        Assert.Equal(animal.CustomerId, result.CustomerId);
        Assert.Equal(animal.BirthDate, result.BirthDate);
        Assert.Equal(animal.Breed, result.Breed);
        Assert.Equal(animal.IsVaccinated, result.IsVaccinated);
        Assert.Equal(default, result.LastEditDate);
        Assert.Equal(default, result.CreationDate);
    }

    [Fact]
    public void Map_UpdateAnimalRequestToAnimal_Test()
    {
        var animal = new UpdateAnimalRequest(
            1,
            "Ben",
            1,
            1,
            "American Curl",
            new DateTime(2020, 03, 03),
            true);

        var result = _mapper.Map<Animal>(animal);

        Assert.Equal(animal.Id, result.Id);
        Assert.Equal(animal.Name, result.Name);
        Assert.Equal(animal.CustomerId, result.CustomerId);
        Assert.Equal(animal.BirthDate, result.BirthDate);
        Assert.Equal(animal.Breed, result.Breed);
        Assert.Equal(animal.IsVaccinated, result.IsVaccinated);
    }

    [Fact]
    public void Map_AnimalTypeToAnimalTypeResponse_Test()
    {
        var animalType = new AnimalType()
        {
            Name = "Cat"
        };

        var result = _mapper.Map<AnimalTypeResponse>(animalType);

        Assert.Equal(default, result.Id);
        Assert.Equal(animalType.Name, result.Name);
    }
}
