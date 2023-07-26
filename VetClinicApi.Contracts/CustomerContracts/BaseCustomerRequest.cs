namespace VetClinicApi.Contracts.CustomerContracts;

public abstract record BaseCustomerRequest(
    string LastName,
    string FirstName,
    string PassportNumber,
    string PhoneNumber,
    DateTime BirthDate);
