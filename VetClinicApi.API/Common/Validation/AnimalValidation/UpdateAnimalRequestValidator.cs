using FluentValidation;

using VetClinicApi.Contracts.AnimalContracts;

namespace VetClinicApi.API.Common.Validation.AnimalValidation;

public class UpdateAnimalRequestValidator : BaseAnimalRequestValidator<UpdateAnimalRequest>
{
    public UpdateAnimalRequestValidator() : base()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}
