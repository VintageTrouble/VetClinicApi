namespace VetClinicApi.Contracts.AnimalContracts;

public record UpdateAnimalRequest(
    int Id,
    string Name,
    int CustomerId,
    int AnimalTypeId,
    string Breed,
    DateTime BirthDate,
    bool IsVaccinated) : BaseAnimalRequest(Name, CustomerId, AnimalTypeId, Breed, BirthDate, IsVaccinated);

