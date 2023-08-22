using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;
using VetClinicApi.Database.Repositories.Base;

namespace VetClinicApi.Application.Services.AnimalHandling;

public class AnimalService : IAnimalService
{
    private readonly IRepository<Animal> _animalRepository;
    private readonly IRepository<AnimalType> _animalTypeRepository;
    private readonly ICustomerRepository _customerRepository;

    public AnimalService(IRepository<Animal> animalRepository, IRepository<AnimalType> animalTypeRepository, ICustomerRepository customerRepository)
    {
        _animalRepository = animalRepository;
        _animalTypeRepository = animalTypeRepository;
        _customerRepository = customerRepository;
    }

    public async Task<Animal> CreateAnimal(Animal? animal)
    {
        if (animal == null)
            throw new ArgumentNullException(nameof(animal), "Animal can't be null.");

        if (await _customerRepository.GetById(animal.CustomerId) is null)
            throw new EntityNotFoundException(animal.CustomerId, nameof(Customer));
        
        if (await _animalTypeRepository.GetById(animal.AnimalTypeId) is null)
            throw new EntityNotFoundException(animal.AnimalTypeId, nameof(AnimalType));

        animal.RegistrationDate = DateTime.Today;
        animal.LastEditDate = DateTime.Today;

        return await _animalRepository.Add(animal);
    }

    public async Task DeleteAnimal(int id)
    {
        try
        {
            await _animalRepository.Delete(id);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new AnimalNotFoundException(id);
        }
    }

    public async Task<Animal> GetAnimal(int id)
    {
        if (await _animalRepository.GetById(id) is not Animal databaseAnimal)
            throw new AnimalNotFoundException(id);
        return databaseAnimal;
    }

    public async Task<Animal> UpdateAnimal(Animal? animal)
    {
        if (animal == null)
            throw new ArgumentNullException(nameof(animal), "Animal can't be null.");

        if (await _animalRepository.GetById(animal.Id) is not Animal databaseAnimal)
            throw new AnimalNotFoundException(animal.Id);


        animal.LastEditDate = DateTime.Today;
        animal.RegistrationDate = databaseAnimal.RegistrationDate;
        try
        {
            return await _animalRepository.Update(animal);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new AnimalNotFoundException(animal.Id);
        }
    }
    public async Task<IEnumerable<Animal>> GetAnimalsByCustomer(int id)
    {
        return await _animalRepository.GetAll(x => x.CustomerId == id);
    }

    //AnimalTypeMethods
    public async Task<AnimalType> CreateAnimalType(AnimalType? animalType)
    {
        if (animalType == null)
            throw new ArgumentNullException(nameof(animalType), "AnimalType can't be null.");
        return await _animalTypeRepository.Add(animalType);
    }

    public async Task DeleteAnimalType(int id)
    {
        try
        {
            await _animalTypeRepository.Delete(id);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new AnimalTypeNotFoundException(id);
        }
    }

    public async Task<IEnumerable<AnimalType>> GetAllAnimalTypes()
    {
        return await _animalTypeRepository.GetAll();
    }

}
