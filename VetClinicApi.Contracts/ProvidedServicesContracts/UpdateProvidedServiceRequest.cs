namespace VetClinicApi.Contracts.ProvidedServicesContracts;

public record UpdateProvidedServiceRequest(
    int Id,
    string Name,
    decimal Price) : BaseProvidedServiceRequest(Name, Price);