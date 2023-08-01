using VetClinicApi.Core.Entities;

namespace VetClinicApi.Application.Services.AnimalHandling;

public interface IAnimalService
{
    Animal CreateAnimal(Animal animal);
    Animal UpdateAnimal(Animal animal);
    Animal GetAnimal(int id);
    void DeleteAnimal(int id);
    IEnumerable<Animal> GetAnimalsByCustomer(int id);
    AnimalType CreateAnimalType(AnimalType animalType);
    void DeleteAnimalType(int id);
    IEnumerable<AnimalType> GetAllAnimalTypes();
}
