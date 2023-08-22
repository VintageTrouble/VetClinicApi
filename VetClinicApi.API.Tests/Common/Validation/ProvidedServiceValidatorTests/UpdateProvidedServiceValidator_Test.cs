using FluentValidation;
using FluentValidation.TestHelper;

using VetClinicApi.API.Common.Validation.ProvidedServiceValidator;
using VetClinicApi.Contracts.ProvidedServicesContracts;

using Xunit;

namespace VetClinicApi.API.Tests.Common.Validation.ProvidedServiceValidatorTests;

public class UpdateProvidedServiceValidator_Test
{
    private readonly IValidator<UpdateProvidedServiceRequest> _validator;

    public UpdateProvidedServiceValidator_Test()
    {
        _validator = new UpdateProvidedServiceValidator();
    }

    [Fact]
    public void Validate_ValidData_ShouldPass_Test()
    {
        var request = new UpdateProvidedServiceRequest(1, "Test", 99.99m);

        var result = _validator.TestValidate(request);

        Assert.True(result.IsValid);
    }

    [Theory]
    [MemberData(nameof(TestData_ProvidedServiceRequests.InvalidUpdateRequests), MemberType = typeof(TestData_ProvidedServiceRequests))]
    public void Validate_InvalidData_ShouldNotPass_Test(UpdateProvidedServiceRequest request, string memberName)
    {
        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(memberName);
    }
}
