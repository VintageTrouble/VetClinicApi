namespace VetClinicApi.Contracts.ProvidedServicesContracts;

public record CreateProvidedServiceRequest(
    string Name,
    decimal Price) : BaseProvidedServiceRequest(Name, Price);