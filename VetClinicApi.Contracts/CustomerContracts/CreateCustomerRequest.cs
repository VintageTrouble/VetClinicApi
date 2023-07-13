namespace VetClinicApi.Contracts.CustomerContracts;

public record CreateCustomerRequest(
    string LastName,
    string FirstName,
    string PassportNumber,
    string PhoneNumber,
    DateTime BirthDate);
