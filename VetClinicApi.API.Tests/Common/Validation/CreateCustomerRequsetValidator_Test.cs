using FluentValidation;
using FluentValidation.TestHelper;

using VetClinicApi.API.Common.Validation.CustomerValidation;
using VetClinicApi.Contracts.CustomerContracts;

using Xunit;
using Xunit.Abstractions;

namespace VetClinicApi.API.Tests.Common.Validation;

public class CreateCustomerRequsetValidator_Test
{
    private IValidator<CreateCustomerRequest> _validator;
    private static IEnumerable<object[]> InvalidCreateCustomerRequests()
    {
        //Empty last name
        yield return new object[]
        {
            new CreateCustomerRequest(
                "",
                "TestFirstname",
                "0000 000000",
                "+7 (999) 999-99-99",
                new DateTime(2000, 1, 1)),
            "LastName"
        };
        //Empty first name
        yield return new object[]
        {
            new CreateCustomerRequest(
                "TestLastName",
                "",
                "0000 000000",
                "+7 (999) 999-99-99",
                new DateTime(2000, 1, 1)),
            "FirstName"
        };
        //Empty passprot
        yield return new object[]
        {
            new CreateCustomerRequest(
                "TestLastName",
                "TestFirstname",
                "",
                "+7 (999) 999-99-99",
                new DateTime(2000, 1, 1)),
            "PassportNumber"
        };
        //Invalid format passport
        yield return new object[]
        {
            new CreateCustomerRequest(
                "TestLastName",
                "TestFirstname",
                "0",
                "+7 (999) 999-99-99",
                new DateTime(2000, 1, 1)),
            "PassportNumber"
        };
        //Empty phone
        yield return new object[]
        {
            new CreateCustomerRequest(
                "TestLastName",
                "TestFirstname",
                "0000 000000",
                "",
                new DateTime(2000, 1, 1)),
            "PhoneNumber"
        };
        //Invalid format phone
        yield return new object[]
        {
            new CreateCustomerRequest(
                "TestLastName",
                "TestFirstname",
                "0000 000000",
                "000",
                new DateTime(2000, 1, 1)),
            "PhoneNumber"
        };
        //Too old person
        yield return new object[]
        {
            new CreateCustomerRequest(
                "TestLastName",
                "TestFirstname",
                "0000 000000",
                "+7 (999) 999-99-99",
                DateTime.MinValue),
            "BirthDate"
        };
        //Too young person
        yield return new object[]
        {
            new CreateCustomerRequest(
                "TestLastName",
                "TestFirstname",
                "0000 000000",
                "+7 (999) 999-99-99",
                DateTime.Today),
            "BirthDate"
        };
    }

    public CreateCustomerRequsetValidator_Test()
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
    [MemberData(nameof(InvalidCreateCustomerRequests))]
    public void Validate_InvalidData_ShouldNotPass_Test(CreateCustomerRequest customer, string memberName)
    {
        var result = _validator.TestValidate(customer);

        result.ShouldHaveValidationErrorFor(memberName);
    }
}
