using FluentValidation;
using FluentValidation.TestHelper;

using VetClinicApi.API.Common.Validation.ProvidedServiceValidator;
using VetClinicApi.Contracts.ProvidedServicesContracts;

using Xunit;

namespace VetClinicApi.API.Tests.Common.Validation.ProvidedServiceValidatorTests;

public class CreateProvidedServiceValidator_Test
{
    private readonly IValidator<CreateProvidedServiceRequest> _validator;

    public CreateProvidedServiceValidator_Test()
	{
        _validator = new CreateProvidedServiceValidator();
	}

    [Fact]
    public void Validate_ValidData_ShouldPass_Test()
    {
        var request = new CreateProvidedServiceRequest("Test", 99.99m);

        var result = _validator.TestValidate(request);

        Assert.True(result.IsValid);
    }

    [Theory]
    [MemberData(nameof(TestData_ProvidedServiceRequests.InvalidCreateRequests), MemberType = typeof(TestData_ProvidedServiceRequests))]
    public void Validate_InvalidData_ShouldNotPass_Test(CreateProvidedServiceRequest request, string memberName)
    {
        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(memberName);
    }
}
