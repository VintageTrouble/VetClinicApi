using FluentValidation;

using VetClinicApi.Contracts.CustomerContracts;

namespace VetClinicApi.API.Common.Validation.CustomerValidation;

public abstract class BaseCustomerRequestValidator<T> : AbstractValidator<T> where T : BaseCustomerRequest
{
    public BaseCustomerRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty();
        RuleFor(x => x.LastName)
            .NotEmpty();
        RuleFor(x => x.PassportNumber)
            .NotEmpty()
            .Matches("[0-9]{4} [0-9]{6}");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches("(8|[+]7) [(][0-9]{3}[)] [0-9]{3}-[0-9]{2}-[0-9]{2}");
        RuleFor(x => x.BirthDate)
            .InclusiveBetween(DateTime.Today.AddYears(-150), DateTime.Today.AddYears(-18))
            .WithMessage("Customer should be older than 18 and younger than 150 years");
    }
}
