using FluentValidation;
using FluentValidation.TestHelper;

using VetClinicApi.API.Common.Validation.CustomerValidation;
using VetClinicApi.API.Tests.Common.Validation.AnimalValidatorTests;
using VetClinicApi.Contracts.CustomerContracts;

using Xunit;

namespace VetClinicApi.API.Tests.Common.Validation.CustomerValidatorTests;

public class UpdateCustomerRequestValidator_Test
{
    private readonly IValidator<UpdateCustomerRequest> _validator;

    public UpdateCustomerRequestValidator_Test()
    {
        _validator = new UpdateCustomerRequestValidator();
    }    

    [Theory]
    [MemberData(nameof(TestData_CustomerRequests.ValidUpdateRequests), MemberType = typeof(TestData_CustomerRequests))]
    public void Validate_ValidData_ShouldPass_Test(UpdateCustomerRequest customer)
    {
        var result = _validator.TestValidate(customer);

        Assert.True(result.IsValid);
    }

    [Theory]
    [MemberData(nameof(TestData_CustomerRequests.InvalidUpdateRequests), MemberType = typeof(TestData_CustomerRequests))]
    public void Validate_InvalidData_ShouldNotPass_Test(UpdateCustomerRequest customer, string memberName)
    {
        var result = _validator.TestValidate(customer);

        result.ShouldHaveValidationErrorFor(memberName);
    }
}
