using FluentValidation;

using VetClinicApi.Contracts.AnimalContracts;

namespace VetClinicApi.API.Common.Validation.AnimalValidation;

public abstract class BaseAnimalRequestValidator<T> : AbstractValidator<T> where T : BaseAnimalRequest
{
    protected BaseAnimalRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.CustomerId)
            .GreaterThan(0);
        RuleFor(x => x.AnimalTypeId)
            .GreaterThan(0);
        RuleFor(x => x.Breed)
            .NotEmpty();
        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.Today.AddDays(1))
            .WithMessage("Animal can't be born in future");
    }
}
