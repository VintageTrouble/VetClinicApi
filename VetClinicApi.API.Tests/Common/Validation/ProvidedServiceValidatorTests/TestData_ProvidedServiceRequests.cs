using VetClinicApi.Contracts.ProvidedServicesContracts;

namespace VetClinicApi.API.Tests.Common.Validation.ProvidedServiceValidatorTests;

internal class TestData_ProvidedServiceRequests
{
    public static IEnumerable<object[]> InvalidCreateRequests()
    {
        //empty name
        yield return new object[]
        {
            new CreateProvidedServiceRequest(
                "",
                99.99m),
            "Name"
        };
        //price less than 0
        yield return new object[]
        {
            new CreateProvidedServiceRequest(
                "",
                -1m),
            "Price"
        };
        //price greater or equal than 100000
        yield return new object[]
        {
            new CreateProvidedServiceRequest(
                "",
                100000m),
            "Price"
        };
    }

    public static IEnumerable<object[]> InvalidUpdateRequests()
    {
        //invalid id
        yield return new object[]
        {
            new UpdateProvidedServiceRequest(
                0,
                "Test",
                99.99m),
            "Id"
        };
        //empty name
        yield return new object[]
        {
            new UpdateProvidedServiceRequest(
                1,
                "",
                99.99m),
            "Name"
        };
        //price less than 0
        yield return new object[]
        {
            new UpdateProvidedServiceRequest(
                1,
                "",
                -1m),
            "Price"
        };
        //price greater or equal than 100000
        yield return new object[]
        {
            new UpdateProvidedServiceRequest(
                1,
                "",
                100000m),
            "Price"
        };
    }
}
