using FluentValidation;

using VetClinicApi.Contracts.ProvidedServicesContracts;

namespace VetClinicApi.API.Common.Validation.ProvidedServiceValidator;

public class UpdateProvidedServiceValidator : BaseProvidedServiceValidator<UpdateProvidedServiceRequest>
{
    public UpdateProvidedServiceValidator() : base()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}
