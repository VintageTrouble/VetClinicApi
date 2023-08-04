using FluentValidation;
using FluentValidation.TestHelper;

using VetClinicApi.API.Common.Validation.AnimalValidation;
using VetClinicApi.Contracts.AnimalContracts;

using Xunit;

namespace VetClinicApi.API.Tests.Common.Validation;

public class CreateAnimalRequestValidator_Test
{
    private readonly IValidator<CreateAnimalRequest> _validator;


    private static IEnumerable<object[]> InvalidCreateAnimalRequests()
    {
        //Empty name
        yield return new object[]
        {
            new CreateAnimalRequest(
            "",
            1,
            1,
            "American Curl",
            new DateTime(2020, 03, 03),
            true),
            "Name"
        };
        //CustomerId less than 1
        yield return new object[]
        {
            new CreateAnimalRequest(
            "Bane",
            0,
            1,
            "American Curl",
            new DateTime(2020, 03, 03),
            true),
            "CustomerId"
        };
        //AnimalTypeId less than 1
        yield return new object[]
        {
            new CreateAnimalRequest(
            "Bane",
            1,
            0,
            "American Curl",
            new DateTime(2020, 03, 03),
            true),
            "AnimalTypeId"
        };
        //Empty Breed
        yield return new object[]
        {
            new CreateAnimalRequest(
            "Bane",
            1,
            1,
            "",
            new DateTime(2020, 03, 03),
            true),
            "Breed"
        };
        //Animal born in future
        yield return new object[]
        {
            new CreateAnimalRequest(
            "Bane",
            1,
            1,
            "American Curl",
            DateTime.Today.AddDays(1),
            true),
            "BirthDate"
        };
    }

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
    [MemberData(nameof(InvalidCreateAnimalRequests))]
    public void Validate_InvalidData_ShouldNotPass_Test(CreateAnimalRequest animal, string memberName)
    {
        var result = _validator.TestValidate(animal);

        result.ShouldHaveValidationErrorFor(memberName);
    }
}
