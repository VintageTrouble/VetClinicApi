using Moq;

using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Application.Services.CustomerHandlig;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;
using Xunit;

namespace VetClinicApi.Application.Tests.Services.CustomerHandling;

public class CustomerService_Test
{
    private readonly Mock<ICustomerRepository> _repository = new();


    [Fact]
    public async Task Create_ValidPerson_Test()
    {
        var customer = new Customer()
        {
            Id = 1,
            BirthDate = new DateTime(2000, 07, 07),
            FirstName = "Дмитрий",
            LastName = "Новиков",
            PassportNumber = "3453-391345",
            PhoneNumber = "8 (911) 090-25-33"
        };
        _repository.Setup(x => x.Add(It.IsAny<Customer>())).ReturnsAsync(customer);

        var customerService = new CustomerService(_repository.Object);
        var result = await customerService.CreateCustomer(customer);

        Assert.Equal(DateTime.Today, result.RegistrationDate);
        Assert.Equal(DateTime.Today, result.LastEditDate);
        Assert.Null(result.LastVisitDate);
    }

    [Fact]
    public async Task Create_CustomerIsNull_Test()
    {
        var customerService = new CustomerService(_repository.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await customerService.CreateCustomer(null));
    }

    [Fact]
    public async Task Create_AddExcistingPassportNumber_Test()
    {
        var customer = new Customer()
        {
            Id = 1,
            BirthDate = new DateTime(2000, 07, 07),
            FirstName = "Дмитрий",
            LastName = "Новиков",
            PassportNumber = "3453-391345",
            PhoneNumber = "8 (911) 090-25-33"
        };

        _repository.Setup(x => x.GetByPassportNumber(It.IsAny<string>())).ReturnsAsync(customer);
        var customerService = new CustomerService(_repository.Object);

        await Assert.ThrowsAsync<PassportNumberConflictExceprion>(async () => await customerService.CreateCustomer(customer));
    }

    [Fact]
    public async Task Update_CustomerSuccessfullyEdited_Test()
    {
        var customer = new Customer()
        {
            Id = 1,
            BirthDate = new DateTime(2000, 07, 07),
            FirstName = "Дмитрий",
            LastName = "Новиков",
            PassportNumber = "3453-391345",
            PhoneNumber = "8 (911) 090-25-33",
            LastEditDate = new DateTime(2015, 02, 12),
            RegistrationDate = new DateTime(1000, 01, 01),
            LastVisitDate = new DateTime(1000, 01, 01)
        };
        var databaseCustomer = new Customer()
        {
            Id = 1,
            BirthDate = new DateTime(2000, 07, 07),
            FirstName = "Дмитрий",
            LastName = "Новиков",
            PassportNumber = "3453-391345",
            PhoneNumber = "8 (911) 090-25-33",
            RegistrationDate = new DateTime(2015, 02, 12),
            LastEditDate = new DateTime(2015, 02, 12),
            LastVisitDate = null
        };

        _repository.Setup(x => x.Update(It.IsAny<Customer>())).ReturnsAsync(customer);
        _repository.Setup(x =>x.GetById(It.IsAny<int>())).ReturnsAsync(databaseCustomer);
        var customerService = new CustomerService(_repository.Object);

        var result = await customerService.UpdateCustomer(customer);

        Assert.Equal(DateTime.Today, result.LastEditDate);
        Assert.Equal(databaseCustomer.RegistrationDate, result.RegistrationDate);
    }

    [Fact]
    public async Task Update_CustomerIsNull_Test()
    {
        var customerService = new CustomerService(_repository.Object);

        await Assert.ThrowsAsync<ArgumentNullException>(async () => await customerService.UpdateCustomer(null));
    }

    [Fact]
    public async Task Update_CustomerNotFound_Test()
    {
        var customer = new Customer()
        {
            Id = 1,
            BirthDate = new DateTime(2000, 07, 07),
            FirstName = "Дмитрий",
            LastName = "Новиков",
            PassportNumber = "3453-391345",
            PhoneNumber = "8 (911) 090-25-33",
            RegistrationDate = new DateTime(2015, 02, 12),
            LastEditDate = new DateTime(2015, 02, 12),
            LastVisitDate = null
        };
        _repository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((Customer?)null);
        var customerService = new CustomerService(_repository.Object);

        await Assert.ThrowsAsync<CustomerNotFoundException>(async () => await customerService.UpdateCustomer(customer));
    }

    [Fact]
    public async Task Update_LastVisitDateTurnsToNull_Test()
    {
        var customer = new Customer()
        {
            Id = 1,
            BirthDate = new DateTime(2000, 07, 07),
            FirstName = "Дмитрий",
            LastName = "Новиков",
            PassportNumber = "3453-391345",
            PhoneNumber = "8 (911) 090-25-33",
            RegistrationDate = new DateTime(2015, 02, 12),
            LastEditDate = new DateTime(2015, 02, 12),
            LastVisitDate = null
        };
        var databaseCustomer = new Customer()
        {
            Id = 1,
            BirthDate = new DateTime(2000, 07, 07),
            FirstName = "Дмитрий",
            LastName = "Новиков",
            PassportNumber = "3453-391345",
            PhoneNumber = "8 (911) 090-25-33",
            RegistrationDate = new DateTime(2015, 02, 12),
            LastEditDate = new DateTime(2015, 02, 12),
            LastVisitDate = new DateTime(2015, 02, 12)
        };
        _repository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(databaseCustomer);
        var customerService = new CustomerService(_repository.Object);

        await Assert.ThrowsAsync<ValueTurnsToNullException>(async () => await customerService.UpdateCustomer(customer));
    }

    [Fact]
    public async Task Get_IdIsNotExist_Test()
    {
        _repository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((Customer?)null);
        var customerService = new CustomerService(_repository.Object);

        await Assert.ThrowsAsync<CustomerNotFoundException>(async () => await customerService.GetCustomer(1));
    }
}
