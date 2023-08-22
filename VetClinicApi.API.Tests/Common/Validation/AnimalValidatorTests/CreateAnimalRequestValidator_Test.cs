using FluentValidation;
using FluentValidation.TestHelper;

using VetClinicApi.API.Common.Validation.AnimalValidation;
using VetClinicApi.Contracts.AnimalContracts;

using Xunit;

namespace VetClinicApi.API.Tests.Common.Validation.AnimalValidatorTests;

public class CreateAnimalRequestValidator_Test
{
    private readonly IValidator<CreateAnimalRequest> _validator;

    public CreateAnimalRequestValidator_Test()
    {
        _validator = new CreateAnimalRequestValidator();
    }

    [Fact]
    public void Validate_ValidData_ShouldPass_Test()
    {
        var animal = new CreateAnimalRequest(
            "Bane",
            1,
            1,
            "American Curl",
            new DateTime(2020, 03, 03),
            true);

        var result = _validator.TestValidate(animal);

        Assert.True(result.IsValid);
    }

    [Theory]
    [MemberData(nameof(TestData_AnimalRequests.InvalidCreateRequests), MemberType = typeof(TestData_AnimalRequests))]
    public void Validate_InvalidData_ShouldNotPass_Test(CreateAnimalRequest animal, string memberName)
    {
        var result = _validator.TestValidate(animal);

        result.ShouldHaveValidationErrorFor(memberName);
    }
}
