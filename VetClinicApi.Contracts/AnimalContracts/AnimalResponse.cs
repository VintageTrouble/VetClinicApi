namespace VetClinicApi.Contracts.AnimalContracts;

public record AnimalResponse(
    int Id,
    string Name,
    int CustomerId,
    int AnimalTypeId,
    string Breed,
    DateTime BirthDate,
    bool IsVaccinated
    );
