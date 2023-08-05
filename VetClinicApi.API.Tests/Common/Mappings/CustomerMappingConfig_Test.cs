using MapsterMapper;

using VetClinicApi.Contracts.CustomerContracts;
using VetClinicApi.Core.Entities;

using Xunit;

namespace VetClinicApi.API.Tests.Common.Mappings;

public class CustomerMappingConfig_Test
{
    private readonly IMapper _mapper;

    public CustomerMappingConfig_Test() 
    { 
        _mapper = AddMapsterForUnitTests.GetMapper();
    }

    [Fact]
    public void Map_CustomerToCustomerResponse_Test()
    {
        var customer = new Customer
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Test",
            BirthDate = DateTime.Today,
            PassportNumber = "0000 000000",
            PhoneNumber = "0 (000) 000-00-00",
            LastEditDate = DateTime.Today,
            LastVisitDate = DateTime.Today,
            RegistrationDate = DateTime.Today
        };

        var result = _mapper.Map<CustomerResponse>(customer);

        Assert.Equal(customer.Id, result.Id);
        Assert.Equal(customer.FirstName, result.FirstName);
        Assert.Equal(customer.LastName, result.LastName);
        Assert.Equal(customer.BirthDate, result.BirthDate);
        Assert.Equal(customer.PassportNumber, result.PassportNumber);
        Assert.Equal(customer.PhoneNumber, result.PhoneNumber);
        Assert.Equal(customer.LastVisitDate, result.LastVisitDate);
    }

    [Fact]
    public void Map_CreateCustomerRequestToCustomer_Test()
    {
        var customer = new CreateCustomerRequest(
            "Test", 
            "Test",
            "0000 000000",
            "+7 (000) 000-00-00",
            DateTime.Today);

        var result = _mapper.Map<Customer>(customer);

        Assert.Equal(default, result.Id);
        Assert.Equal(customer.FirstName, result.FirstName);
        Assert.Equal(customer.LastName, result.LastName);
        Assert.Equal(customer.BirthDate, result.BirthDate);
        Assert.Equal(customer.PassportNumber, result.PassportNumber);
        Assert.Equal(customer.PhoneNumber, result.PhoneNumber);
        Assert.Equal(default, result.RegistrationDate);
        Assert.Equal(default, result.LastEditDate);
        Assert.Null(result.LastVisitDate);
    }

    [Fact]
    public void Map_UpdateCustomerRequestRequestToCustomer_Test()
    {
        var customer = new UpdateCustomerRequest(
            1,
            "Test",
            "Test",
            "0000 000000",
            "+7 (000) 000-00-00",
            DateTime.Today, 
            new DateTime(2000, 1, 1));

        var result = _mapper.Map<Customer>(customer);

        Assert.Equal(customer.Id, result.Id);
        Assert.Equal(customer.FirstName, result.FirstName);
        Assert.Equal(customer.LastName, result.LastName);
        Assert.Equal(customer.BirthDate, result.BirthDate);
        Assert.Equal(customer.PassportNumber, result.PassportNumber);
        Assert.Equal(customer.PhoneNumber, result.PhoneNumber);
        Assert.Equal(customer.LastVisitDate, result.LastVisitDate);
    }
}
