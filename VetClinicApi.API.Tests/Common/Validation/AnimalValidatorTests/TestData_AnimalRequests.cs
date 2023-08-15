using VetClinicApi.Contracts.AnimalContracts;

namespace VetClinicApi.API.Tests.Common.Validation.AnimalValidatorTests;

internal static class TestData_AnimalRequests
{
    public static IEnumerable<object[]> InvalidCreateRequests()
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

    public static IEnumerable<object[]> InvalidUpdateRequests()
    {
        // Invalid Id
        yield return new object[]
        {
            new UpdateAnimalRequest(
            -1,
            "Bane",
            1,
            1,
            "American Curl",
            new DateTime(2020, 03, 03),
            true),
            "Id"
        };
        // Empty name
        yield return new object[]
        {
            new UpdateAnimalRequest(
            -1,
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
            new UpdateAnimalRequest(
            1,
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
            new UpdateAnimalRequest(
            1,
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
            new UpdateAnimalRequest(
            1,
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
            new UpdateAnimalRequest(
            1,
            "Bane",
            1,
            1,
            "American Curl",
            DateTime.Today.AddDays(1),
            true),
            "BirthDate"
        };
    }
}
