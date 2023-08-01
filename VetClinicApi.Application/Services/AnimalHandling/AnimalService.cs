using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

namespace VetClinicApi.Application.Services.AnimalHandling;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IAbstractRepository<AnimalType> _animalTypeRepository;

    public AnimalService(IAnimalRepository animalRepository, IAbstractRepository<AnimalType> animalTypeRepository)
    {
        _animalRepository = animalRepository;
        _animalTypeRepository = animalTypeRepository;
    }

    public Animal CreateAnimal(Animal? animal)
    {
        if (animal == null)
            throw new ArgumentNullException(nameof(animal), "Animal can't be null.");

        animal.RegistrationDate = DateTime.Today;
        animal.LastEditDate = DateTime.Today;

        return _animalRepository.Add(animal);
    }

    public void DeleteAnimal(int id)
    {
        try
        {
            _animalRepository.Delete(id);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new AnimalNotFoundException(id);
        }
    }

    public Animal GetAnimal(int id)
    {
        if (_animalRepository.GetById(id) is not Animal databaseAnimal)
            throw new AnimalNotFoundException(id);
        return databaseAnimal;
    }

    public Animal UpdateAnimal(Animal? animal)
    {
        if (animal == null)
            throw new ArgumentNullException(nameof(animal), "Animal can't be null.");

        if (_animalRepository.GetById(animal.Id) is not Animal databaseAnimal)
            throw new AnimalNotFoundException(animal.Id);


        animal.LastEditDate = DateTime.Today;
        animal.RegistrationDate = databaseAnimal.RegistrationDate;
        try
        {
            return _animalRepository.Update(animal);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new AnimalNotFoundException(animal.Id);
        }
    }
    public IEnumerable<Animal> GetAnimalsByCustomer(int id)
    {
        return _animalRepository.GetAll(x => x.CustomerId == id);
    }

    //AnimalTypeMethods
    public AnimalType CreateAnimalType(AnimalType? animalType)
    {
        if (animalType == null)
            throw new ArgumentNullException(nameof(animalType), "AnimalType can't be null.");
        return _animalTypeRepository.Add(animalType);
    }

    public void DeleteAnimalType(int id)
    {
        try
        {
            _animalTypeRepository.Delete(id);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new AnimalTypeNotFoundException(id);
        }
    }

    public IEnumerable<AnimalType> GetAllAnimalTypes()
    {
        return _animalTypeRepository.GetAll();
    }

}
