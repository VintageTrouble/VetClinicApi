using FluentValidation;

using VetClinicApi.Contracts.ProvidedServicesContracts;

namespace VetClinicApi.API.Common.Validation.ProvidedServiceValidator;

public class BaseProvidedServiceValidator<T> : AbstractValidator<T> where T : BaseProvidedServiceRequest 
{
	public BaseProvidedServiceValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty();
		RuleFor(x => x.Price)
			.GreaterThanOrEqualTo(0m)
			.LessThan(100000m);
	}
}
