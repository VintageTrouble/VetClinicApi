using FluentValidation;
using FluentValidation.TestHelper;

using VetClinicApi.API.Common.Validation.CustomerValidation;
using VetClinicApi.API.Tests.Common.Validation.AnimalValidatorTests;
using VetClinicApi.Contracts.CustomerContracts;

using Xunit;

namespace VetClinicApi.API.Tests.Common.Validation.CustomerValidatorTests;

public class CreateCustomerRequestValidator_Test
{
    private readonly IValidator<CreateCustomerRequest> _validator;
    

    public CreateCustomerRequestValidator_Test()
    {
        _validator = new CreateCustomerRequsetValidator();
    }

    [Fact]
    public void Validate_ValidData_ShouldPass_Test()
    {
        var customer = new CreateCustomerRequest(
            "TestLastName",
            "TestFirstname",
            "0000 000000",
            "+7 (999) 999-99-99",
            new DateTime(2000, 1, 1));

        var result = _validator.TestValidate(customer);

        Assert.True(result.IsValid);
    }

    [Theory]
    [MemberData(nameof(TestData_CustomerRequests.InvalidCreateRequests), MemberType = typeof(TestData_CustomerRequests))]
    public void Validate_InvalidData_ShouldNotPass_Test(CreateCustomerRequest customer, string memberName)
    {
        var result = _validator.TestValidate(customer);

        result.ShouldHaveValidationErrorFor(memberName);
    }
}
