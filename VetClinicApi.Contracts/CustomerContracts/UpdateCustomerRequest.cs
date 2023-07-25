namespace VetClinicApi.Contracts.CustomerContracts;

public record UpdateCustomerRequest(
    int Id,
    string LastName,
    string FirstName,
    string PassportNumber,
    string PhoneNumber,
    DateTime BirthDate,
    DateTime? LastVisitDate) : BaseCustomerRequest(LastName, FirstName, PassportNumber, PhoneNumber, BirthDate);
