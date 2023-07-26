using FluentValidation;
using FluentValidation.TestHelper;

using VetClinicApi.API.Common.Validation.CustomerValidation;
using VetClinicApi.Contracts.CustomerContracts;

using Xunit;

namespace VetClinicApi.API.Tests.Common.Validation;

public class UpdateCustomerRequsetValidator_Test
{
    private readonly IValidator<UpdateCustomerRequest> _validator;

    public UpdateCustomerRequsetValidator_Test()
    {
        _validator = new UpdateCustomerRequestValidator();
    }

    private static IEnumerable<object[]> ValidRequests()
    {
        yield return new object[]
        {
            new UpdateCustomerRequest(
                1,
                "TestLastName",
                "TestFirstname",
                "0000 000000",
                "+7 (999) 999-99-99",
                new DateTime(2000, 1, 1),
                new DateTime(2000, 1, 1))
        };
        yield return new object[]
        {
            new UpdateCustomerRequest(
                1,
                "TestLastName",
                "TestFirstname",
                "0000 000000",
                "+7 (999) 999-99-99",
                new DateTime(2000, 1, 1),
                null)
        };
    }

    private static IEnumerable<object[]> InvalidRequests()
    {
        //Invalid Id
        yield return new object[]
        {
            new UpdateCustomerRequest(
                -1,
                "",
                "TestFirstname",
                "0000 000000",
                "+7 (999) 999-99-99",
                new DateTime(2000, 1, 1),
                new DateTime(2000, 1, 1)),
            "Id"
        };
        //Empty last name
        yield return new object[]
        {
            new UpdateCustomerRequest(
                1,
                "",
                "TestFirstname",
                "0000 000000",
                "+7 (999) 999-99-99",
                new DateTime(2000, 1, 1),
                new DateTime(2000, 1, 1)),
            "LastName"
        };
        //Empty first name
        yield return new object[]
        {
            new UpdateCustomerRequest(
                1,
                "TestLastName",
                "",
                "0000 000000",
                "+7 (999) 999-99-99",
                new DateTime(2000, 1, 1),
                new DateTime(2000, 1, 1)),
            "FirstName"
        };
        //Empty passprot
        yield return new object[]
        {
            new UpdateCustomerRequest(
                1,
                "TestLastName",
                "TestFirstname",
                "",
                "+7 (999) 999-99-99",
                new DateTime(2000, 1, 1),
                new DateTime(2000, 1, 1)),
            "PassportNumber"
        };
        //Invalid format passport
        yield return new object[]
        {
            new UpdateCustomerRequest(
                1,
                "TestLastName",
                "TestFirstname",
                "0",
                "+7 (999) 999-99-99",
                new DateTime(2000, 1, 1), 
                new DateTime(2000, 1, 1)),
            "PassportNumber"
        };
        //Empty phone
        yield return new object[]
        {
            new UpdateCustomerRequest(
                1,
                "TestLastName",
                "TestFirstname",
                "0000 000000",
                "",
                new DateTime(2000, 1, 1),
                new DateTime(2000, 1, 1)),
            "PhoneNumber"
        };
        //Invalid format phone
        yield return new object[]
        {
            new UpdateCustomerRequest(
                1,
                "TestLastName",
                "TestFirstname",
                "0000 000000",
                "000",
                new DateTime(2000, 1, 1),
                new DateTime(2000, 1, 1)),
            "PhoneNumber"
        };
        //Too old person
        yield return new object[]
        {
            new UpdateCustomerRequest(
                1,
                "TestLastName",
                "TestFirstname",
                "0000 000000",
                "+7 (999) 999-99-99",
                DateTime.MinValue,
                new DateTime(2000, 1, 1)),
            "BirthDate"
        };
        //Too young person
        yield return new object[]
        {
            new UpdateCustomerRequest(
                1,
                "TestLastName",
                "TestFirstname",
                "0000 000000",
                "+7 (999) 999-99-99",
                DateTime.Today, 
                new DateTime(2000, 1, 1)),
            "BirthDate"
        };
        //Last visit in future
        yield return new object[]
        {
            new UpdateCustomerRequest(
                1,
                "TestLastName",
                "TestFirstname",
                "0000 000000",
                "+7 (999) 999-99-99",
                DateTime.Today,
                DateTime.Today.AddDays(1)),
            "LastVisitDate"
        };
    }

    [Theory]
    [MemberData(nameof(ValidRequests))]
    public void Validate_ValidData_ShouldPass_Test(UpdateCustomerRequest customer)
    {
        var result = _validator.TestValidate(customer);

        Assert.True(result.IsValid);
    }

    [Theory]
    [MemberData(nameof(InvalidRequests))]
    public void Validate_InvalidData_ShouldNotPass_Test(UpdateCustomerRequest customer, string memberName)
    {
        var result = _validator.TestValidate(customer);

        result.ShouldHaveValidationErrorFor(memberName);
    }
}
