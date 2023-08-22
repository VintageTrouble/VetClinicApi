using Moq;

using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Application.Infrastructure.DateTimeProvider;
using VetClinicApi.Application.Services.AnimalHandling;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

using Xunit;

namespace VetClinicApi.Application.Tests.Services.AmimalHandling;

public class AnimalService_Test
{
    private readonly Mock<IDateTimeProvider> _dateTimeProvider = new();
    private readonly Mock<IAnimalRepository> _animalRepository = new();
    private readonly Mock<IAbstractRepository<AnimalType>> _animalTypeRepository = new();
    private readonly Mock<ICustomerRepository> _customerRepository = new();
    private readonly DateTime _testDateTime = new(2022, 07, 07);

    public AnimalService_Test()
    {
        _dateTimeProvider.Setup(x => x.UtcNow).Returns(_testDateTime);
    }

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
        var animalType = new AnimalType()
        {
            Id = 1,
            Name = "Test",
        };
        var customer = new Customer()
        {
            Id = 1,
            BirthDate = new DateTime(2000, 07, 07),
            FirstName = "Дмитрий",
            LastName = "Новиков",
            PassportNumber = "3453-391345",
            PhoneNumber = "8 (911) 090-25-33"
        };

        _animalTypeRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(animalType);
        _customerRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(customer);
        _animalRepository.Setup(x => x.Add(It.IsAny<Animal>())).ReturnsAsync(animal);

        var animalService = new AnimalService(_dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);
        var result = await animalService.CreateAnimal(animal);

        Assert.Equal(_testDateTime, result.CreationDate);
        Assert.Equal(_testDateTime, result.LastEditDate);
    }

    [Fact]
    public async Task Create_AnimalIsNull_Test()
    {
        var animalService = new AnimalService(_dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async() => await animalService.CreateAnimal(null));
    }

    [Fact]
    public async Task Create_AnimalTypeByIdIsNotFound_Test()
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
        };

        _animalTypeRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(() => null);

        var animalService = new AnimalService(_dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);

        await Assert.ThrowsAsync<EntityNotFoundException>(async () => await animalService.CreateAnimal(animal));
    }

    [Fact]
    public async Task Create_CustomerByIdIsNotFound_Test()
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
        };
        var animalType = new AnimalType()
        {
            Id = 1,
            Name = "Test",
        };

        _animalTypeRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(animalType);
        _customerRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(() => null);
        var animalService = new AnimalService(_dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);

        await Assert.ThrowsAsync<EntityNotFoundException>(async () => await animalService.CreateAnimal(animal));
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
            CreationDate = new DateTime(1000, 01, 01),
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
            CreationDate = new DateTime(1000, 01, 01),
        };

        _animalRepository.Setup(x => x.Update(It.IsAny<Animal>())).ReturnsAsync(animal);
        _animalRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(databaseAnimal);
        var animalService = new AnimalService(_dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);

        var result = await animalService.UpdateAnimal(animal);

        Assert.Equal(_testDateTime, result.LastEditDate);
        Assert.Equal(databaseAnimal.CreationDate, result.CreationDate);
    }

    [Fact]
    public async Task Update_AnimalIsNull_Test()
    {
        var animalService = new AnimalService(_dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await animalService.UpdateAnimal(null));
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
            CreationDate = new DateTime(1000, 01, 01),
        };
        _animalRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(() => null);
        var animalService = new AnimalService(_dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);

        await Assert.ThrowsAsync<AnimalNotFoundException>(async () => await animalService.UpdateAnimal(animal));
    }

    [Fact]
    public async Task Update_RepositoryUpdateThrowsArgumentOutOfRangeException_AnimalNotFoundExceptionResult_Test()
    {
        var animal = new Animal() { Id = 1 };

        _animalRepository.Setup(x => x.Update(It.IsAny<Animal>())).ThrowsAsync(new ArgumentOutOfRangeException());
        var animalService = new AnimalService(_dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);

        var exception = await Assert.ThrowsAsync<AnimalNotFoundException>(async () => await animalService.UpdateAnimal(animal));

        Assert.Equal("Animal with id = 1 not found.", exception.Message);
    }

    [Fact]
    public async Task Get_IdIsNotExist_Test()
    {
        _animalRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(() => null);
        var animalService = new AnimalService(_dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);

        await Assert.ThrowsAsync<AnimalNotFoundException>(async () => await animalService.GetAnimal(1));
    }

    [Fact]
    public async Task Delete_AnimalNotFound_Test()
    {
        _animalRepository.Setup(x => x.Delete(It.IsAny<int>())).ThrowsAsync(new ArgumentOutOfRangeException());
        var animalService = new AnimalService(_dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);

        await Assert.ThrowsAsync<AnimalNotFoundException>(async () => await animalService.DeleteAnimal(1));
    }

    //AnimalType Tets
    [Fact]
    public async Task Create_AnimaTypelIsNull_Test()
    {
        var animalTypeService = new AnimalService( _dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await animalTypeService.CreateAnimalType(null));
    }

    [Fact]
    public async Task Delete_AnimalTypeNotFound_Test()
    {
        _animalTypeRepository.Setup(x => x.Delete(It.IsAny<int>())).ThrowsAsync(new ArgumentOutOfRangeException());
        var animalTypeService = new AnimalService(_dateTimeProvider.Object, _animalRepository.Object, _animalTypeRepository.Object, _customerRepository.Object);

        await Assert.ThrowsAsync<AnimalTypeNotFoundException>(async () => await animalTypeService.DeleteAnimalType(1));
    }
}
