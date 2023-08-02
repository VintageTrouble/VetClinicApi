using Moq;

using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Application.Services.AnimalHandling;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

using Xunit;

namespace VetClinicApi.Application.Tests.Services.AmimalHandling;

public class AnimalService_Test
{
    private readonly Mock<IAnimalRepository> _animalRepository = new();
    private readonly Mock<IAbstractRepository<AnimalType>> _animalTypeRepository = new();

    [Fact]
    public async Task Create_ValidAnimal_Test()
    {
        var animal = new Animal()
        {
            Id = 1,
            BirthDate = new DateTime(2015, 07, 07),
            CustomerId = 1,
            AnimalTypeId = 1,
            Name = "Test",
            Breed = "Test2",
            IsVaccinated = true
        };
        _animalRepository.Setup(x => x.Add(It.IsAny<Animal>())).ReturnsAsync(animal);

        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);
        var result = await animalService.CreateAnimal(animal);

        Assert.Equal(DateTime.Today, result.RegistrationDate);
        Assert.Equal(DateTime.Today, result.LastEditDate);
    }

    [Fact]
    public async Task Create_AnimalIsNull_Test()
    {
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.ThrowsAsync<ArgumentNullException>(() => animalService.CreateAnimal(null));
    }

    [Fact]
    public async Task Update_AnimalSuccessfullyEdited_Test()
    {
            var animal = new Animal()
        {
            Id = 1,
            BirthDate = new DateTime(2015, 07, 07),
            CustomerId = 1,
            AnimalTypeId = 1,
            Name = "Test",
            Breed = "Test2",
            IsVaccinated = true,
            LastEditDate = new DateTime(2015, 02, 12),
            RegistrationDate = new DateTime(1000, 01, 01),
        };
        var databaseAnimal = new Animal()
        {
            Id = 1,
            BirthDate = new DateTime(2015, 07, 07),
            CustomerId = 1,
            AnimalTypeId = 1,
            Name = "Test",
            Breed = "Test2",
            IsVaccinated = true,
            LastEditDate = new DateTime(2015, 02, 12),
            RegistrationDate = new DateTime(1000, 01, 01),
        };

        _animalRepository.Setup(x => x.Update(It.IsAny<Animal>())).ReturnsAsync(animal);
        _animalRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(databaseAnimal);
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        var result = await animalService.UpdateAnimal(animal);

        Assert.Equal(DateTime.Today, result.LastEditDate);
        Assert.Equal(databaseAnimal.RegistrationDate, result.RegistrationDate);
    }

    [Fact]
    public async Task Update_AnimalIsNull_Test()
    {
        _animalRepository.Setup(x => x.Update(It.IsAny<Animal>())).ReturnsAsync((Animal)null);
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.ThrowsAsync<ArgumentNullException>(() => animalService.UpdateAnimal(null));
    }

    [Fact]
    public async Task Update_AnimalNotFound_Test()
    {
        var animal = new Animal()
        {
            Id = 1,
            BirthDate = new DateTime(2015, 07, 07),
            CustomerId = 1,
            AnimalTypeId = 1,
            Name = "Test",
            Breed = "Test2",
            IsVaccinated = true,
            LastEditDate = new DateTime(2015, 02, 12),
            RegistrationDate = new DateTime(1000, 01, 01),
        };
        _animalRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((Animal)null);
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.ThrowsAsync<AnimalNotFoundException>(() => animalService.UpdateAnimal(animal));
    }

    [Fact]
    public async Task Get_IdIsNotExist_Test()
    {
        _animalRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((Animal)null);
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.ThrowsAsync<AnimalNotFoundException>(() => animalService.GetAnimal(1));
    }

    [Fact]
    public async Task Delete_AnimalNotFound_Test()
    {
        _animalRepository.Setup(x => x.Delete(It.IsAny<int>())).Throws<ArgumentOutOfRangeException>();
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.ThrowsAsync<AnimalNotFoundException>(() => animalService.DeleteAnimal(1));
    }

    //AnimalType Tets
    [Fact]
    public async Task Create_AnimaTypelIsNull_Test()
    {
        var animalTypeService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.ThrowsAsync<ArgumentNullException>(() => animalTypeService.CreateAnimalType(null));
    }

    [Fact]
    public async Task Delete_AnimalTypeNotFound_Test()
    {
        _animalTypeRepository.Setup(x => x.Delete(It.IsAny<int>())).Throws<ArgumentOutOfRangeException>();
        var animalTypeService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.ThrowsAsync<AnimalTypeNotFoundException>(() => animalTypeService.DeleteAnimalType(1));
    }
}
