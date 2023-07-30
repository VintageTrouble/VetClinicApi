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
    public void Create_ValidAnimal_Test()
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
        _animalRepository.Setup(x => x.Add(It.IsAny<Animal>())).Returns(animal);

        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);
        var result = animalService.CreateAnimal(animal);

        Assert.Equal(DateTime.Today, result.RegistrationDate);
        Assert.Equal(DateTime.Today, result.LastEditDate);
    }

    [Fact]
    public void Create_AnimalIsNull_Test()
    {
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.Throws<ArgumentNullException>(() => animalService.CreateAnimal(null));
    }

    [Fact]
    public void Update_AnimalSuccessfullyEdited_Test()
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

        _animalRepository.Setup(x => x.Update(It.IsAny<Animal>())).Returns(animal);
        _animalRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(databaseAnimal);
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        var result = animalService.UpdateAnimal(animal);

        Assert.Equal(DateTime.Today, result.LastEditDate);
        Assert.Equal(databaseAnimal.RegistrationDate, result.RegistrationDate);
    }

    [Fact]
    public void Update_AnimalIsNull_Test()
    {
        _animalRepository.Setup(x => x.Update(It.IsAny<Animal>())).Returns<Animal>(null);
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.Throws<ArgumentNullException>(() => animalService.UpdateAnimal(null));
    }

    [Fact]
    public void Update_AnimalNotFound_Test()
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
        _animalRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns<Animal>(null);
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.Throws <AnimalNotFoundException>(() => animalService.UpdateAnimal(animal));
    }

    [Fact]
    public void Get_IdIsNotExist_Test()
    {
        _animalRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns<Animal>(null);
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.Throws<AnimalNotFoundException>(() => animalService.GetAnimal(1));
    }

    [Fact]
    public void Delete_AnimalNotFound_Test()
    {
        _animalRepository.Setup(x => x.Delete(It.IsAny<int>())).Throws<ArgumentOutOfRangeException>();
        var animalService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.Throws<AnimalNotFoundException>(() => animalService.DeleteAnimal(1));
    }

    //AnimalType Tets
    [Fact]
    public void Create_AnimaTypelIsNull_Test()
    {
        var animalTypeService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.Throws<ArgumentNullException>(() => animalTypeService.CreateAnimalType(null));
    }

    [Fact]
    public void Delete_AnimalTypeNotFound_Test()
    {
        _animalTypeRepository.Setup(x => x.Delete(It.IsAny<int>())).Throws<ArgumentOutOfRangeException>();
        var animalTypeService = new AnimalService(_animalRepository.Object, _animalTypeRepository.Object);

        Assert.Throws<AnimalTypeNotFoundException>(() => animalTypeService.DeleteAnimalType(1));
    }
}
