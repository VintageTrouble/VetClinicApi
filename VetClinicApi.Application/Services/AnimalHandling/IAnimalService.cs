using VetClinicApi.Core.Entities;

namespace VetClinicApi.Application.Services.AnimalHandling;

public interface IAnimalService
{
    Task<Animal> CreateAnimal(Animal animal);
    Task<Animal> UpdateAnimal(Animal animal);
    Task<Animal> GetAnimal(int id);
    Task DeleteAnimal(int id);
    Task<IEnumerable<Animal>> GetAnimalsByCustomer(int id);
    Task<AnimalType> CreateAnimalType(AnimalType animalType);
    Task DeleteAnimalType(int id);
    Task<IEnumerable<AnimalType>> GetAllAnimalTypes();
}
