namespace VetClinicApi.Contracts.AnimalContracts;

public abstract record BaseAnimalRequest(
    string Name,
    int CustomerId,
    int AnimalTypeId,
    string Breed,
    DateTime BirthDate,
    bool IsVaccinated);
