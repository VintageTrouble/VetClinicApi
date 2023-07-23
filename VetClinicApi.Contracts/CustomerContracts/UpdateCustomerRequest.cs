namespace VetClinicApi.Contracts.CustomerContracts;

public record UpdateCustomerRequest(
    int Id,
    string LastName,
    string FirstName,
    string PassportNumber,
    string PhoneNumber,
    DateTime BirthDate) : BaseCustomerRequest(LastName, FirstName, PassportNumber, PhoneNumber, BirthDate);
