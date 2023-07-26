namespace VetClinicApi.Contracts.CustomerContracts;

public record CustomerResponse(
    int Id,
    string LastName,
    string FirstName,
    DateTime BirthDate,
    string PassportNumber,
    string PhoneNumber,
    DateTime? LastVisitDate);
