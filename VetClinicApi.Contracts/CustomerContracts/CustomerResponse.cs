namespace VetClinicApi.Contracts.CustomerContracts;

public record CustomerResponse(
    int Id,
    string LastName,
    string FirstName,
    DateTime BitthDate,
    string PassportNumber,
    string PhoneNumber,
    DateTime? LastVisitDate);
