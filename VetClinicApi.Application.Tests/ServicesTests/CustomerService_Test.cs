using Castle.Core.Resource;

using FluentMigrator.Builders.IfDatabase;

using Moq;

using System.Data;

using VetClinicApi.Application.Services.CustomerHandlig;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

using Xunit;

namespace VetClinicApi.API.Tests.ServicesTests
{
    public class CustomerService_Test
    {
        private CustomerService _customerService;
        private Mock<IAbstractRepository<Customer>> _repository = new Mock<IAbstractRepository<Customer>>();

        public static IEnumerable<object[]> CreateObjectCustomer_ValidFields()
        {
            yield return new object[]
            {
            new Customer()
            {
            Id = 1,
            BirthDate = new DateTime(2000, 07, 07),
            FirstName = "Дмитрий",
            LastName = "Новиков",
            PassportNumber = "3453-391345",
            PhoneNumber = "8 (911) 090-25-33"
            },
            new Customer()
            {
                Id = 1,
                BirthDate = new DateTime(2000, 07, 07),
                FirstName = "Дмитрий",
                LastName = "Новиков",
                PassportNumber = "3453-391345",
                PhoneNumber = "8 (911) 090-25-33",
                RegistrationDate = DateTime.Today,
                LastEditDate = DateTime.Today,
                LastVisitDate = null
            }
           };
        }
        public static IEnumerable<object[]> CreateObjectCustomer_RequiredFieldNull()
        {
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 07, 07),
                    FirstName = "",
                    LastName = "Новиков",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "8 (911) 090-25-33"
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "8 (911) 090-25-33"
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "",
                    PhoneNumber = "8 (911) 090-25-33"
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "",
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "",
                    PhoneNumber = "8 (911) 090-25-33"
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2021, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "8 (911) 090-25-33"
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(1800, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "8 (911) 090-25-33"
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2024, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "8 (911) 090-25-33"
                },
            };
        }
        public static IEnumerable<object[]> UpdateObjectCustomer_LastEditDateUpdate()
        {
            yield return new object[]
            {
                new Customer()
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
                },
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "8 (911) 090-25-33",
                    RegistrationDate = new DateTime(2015, 02, 12),
                    LastEditDate = DateTime.Today,
                    LastVisitDate = null
                }
            };
        }
        public static IEnumerable<object[]> UpdateObjectCustomer_RequiredFieldNull()
        {
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 07, 07),
                    FirstName = "",
                    LastName = "Новиков",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "8 (911) 090-25-33",
                    RegistrationDate = new DateTime(2015, 02, 12),
                    LastEditDate = new DateTime(2015, 02, 12),
                    LastVisitDate = null
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "8 (911) 090-25-33",
                    RegistrationDate = new DateTime(2015, 02, 12),
                    LastEditDate = new DateTime(2015, 02, 12),
                    LastVisitDate = null
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "",
                    PhoneNumber = "8 (911) 090-25-33",
                    RegistrationDate = new DateTime(2015, 02, 12),
                    LastEditDate = new DateTime(2015, 02, 12),
                    LastVisitDate = null
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "",
                    RegistrationDate = new DateTime(2015, 02, 12),
                    LastEditDate = new DateTime(2015, 02, 12),
                    LastVisitDate = null
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2000, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "",
                    PhoneNumber = "8 (911) 090-25-33",
                    RegistrationDate = new DateTime(2015, 02, 12),
                    LastEditDate = new DateTime(2015, 02, 12),
                    LastVisitDate = null
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2021, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "8 (911) 090-25-33",
                    RegistrationDate = new DateTime(2015, 02, 12),
                    LastEditDate = new DateTime(2015, 02, 12),
                    LastVisitDate = null
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(1800, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "8 (911) 090-25-33",
                    RegistrationDate = new DateTime(2015, 02, 12),
                    LastEditDate = new DateTime(2015, 02, 12),
                    LastVisitDate = null
                },
            };
            yield return new object[]
            {
                new Customer()
                {
                    Id = 1,
                    BirthDate = new DateTime(2024, 07, 07),
                    FirstName = "Дмитрий",
                    LastName = "Новиков",
                    PassportNumber = "3453-391345",
                    PhoneNumber = "8 (911) 090-25-33",
                    RegistrationDate = new DateTime(2015, 02, 12),
                    LastEditDate = new DateTime(2015, 02, 12),
                    LastVisitDate = null
                },
            };
        }

        [Theory]
        [MemberData(nameof(CreateObjectCustomer_ValidFields))]

        public void CustomerService_CreateCustomer_ValidPerson_Test(Customer customer, Customer expected)
        {
            _repository.Setup(x => x.Add(It.IsAny<Customer>())).Returns(customer);
            _customerService = new CustomerService(_repository.Object);
            var result = _customerService.CreateCustomer(customer);


            Assert.Equal(expected.RegistrationDate, result.RegistrationDate);
            Assert.Equal(expected.FirstName, result.FirstName);
            Assert.Equal(expected.LastName, result.LastName);
            Assert.Equal(expected.PhoneNumber, result.PhoneNumber);
            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.BirthDate, result.BirthDate);
            Assert.Equal(expected.LastEditDate, result.LastEditDate);
            Assert.Equal(expected.LastVisitDate, result.LastVisitDate);
            Assert.Equal(expected.PassportNumber, result.PassportNumber);
        }

        [Theory]
        [MemberData(nameof(CreateObjectCustomer_RequiredFieldNull))]
        public void CustomerService_Create_NotNullRequiredFields_Test(Customer customer)
        {
            _repository.Setup(x => x.Add(It.IsAny<Customer>())).Returns(customer);
            _customerService = new CustomerService(_repository.Object);
            Assert.Throws<InvalidOperationException>(() => _customerService.CreateCustomer(customer));
        }

        [Fact]
        public void CustomerService_Update_CustomerIsNull_Test()
        {
            Customer customer = null;
            _repository.Setup(x => x.Update(It.IsAny<Customer>())).Returns(customer);
            _customerService = new CustomerService(_repository.Object);
            Assert.Throws<Exception>(() => _customerService.UpdateCustomer(null));
        }

        [Theory]
        [MemberData(nameof(UpdateObjectCustomer_LastEditDateUpdate))]
        public void CustomerService_UpdateLastEditDate_Test(Customer customer, Customer expected)
        {
            _repository.Setup(x => x.Update(It.IsAny<Customer>())).Returns(customer);
            _customerService = new CustomerService(_repository.Object);
            var result = _customerService.UpdateCustomer(customer);

            Assert.Equal(expected.LastEditDate, result.LastEditDate);
        }

        [Theory]
        [MemberData(nameof(UpdateObjectCustomer_RequiredFieldNull))]
        public void CustomerService_Update_NotNullRequiredFields_Test(Customer customer)
        {
            _repository.Setup(x => x.Update(It.IsAny<Customer>())).Returns(customer);
            _customerService = new CustomerService(_repository.Object);
            Assert.Throws<InvalidOperationException>(() => _customerService.UpdateCustomer(customer));
        }

    }
}
