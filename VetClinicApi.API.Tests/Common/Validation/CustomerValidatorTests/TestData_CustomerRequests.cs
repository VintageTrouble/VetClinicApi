using VetClinicApi.Contracts.CustomerContracts;

namespace VetClinicApi.API.Tests.Common.Validation.CustomerValidatorTests;

internal class TestData_CustomerRequests
{
    public static IEnumerable<object[]> InvalidCreateRequests()
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

    public static IEnumerable<object[]> InvalidUpdateRequests()
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

    public static IEnumerable<object[]> ValidUpdateRequests()
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
}
