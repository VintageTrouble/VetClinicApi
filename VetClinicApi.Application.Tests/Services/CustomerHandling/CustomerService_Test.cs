using Moq;

using VetClinicApi.Application.Common.Exceptions;
using VetClinicApi.Application.Services.CustomerHandlig;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

using Xunit;

namespace VetClinicApi.Application.Tests.Services.CustomerHandling
{
    public class Test
    {
        private CustomerService _customerService;
        private Mock<ICustomerRepository> _repository = new Mock<ICustomerRepository>();


        [Fact]
        public void Create_ValidPerson_Test()
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
            _repository.Setup(x => x.Add(It.IsAny<Customer>())).Returns(customer);

            _customerService = new CustomerService(_repository.Object);
            var result = _customerService.CreateCustomer(customer);


            Assert.Equal(DateTime.Today, result.RegistrationDate);
            Assert.Equal(DateTime.Today, result.LastEditDate);
            Assert.Null(result.LastVisitDate);
        }

        [Fact]
        public void Create_CustomerIsNull_Test()
        {
            _customerService = new CustomerService(_repository.Object);
            Assert.Throws<ArgumentNullException>(() => _customerService.CreateCustomer(null));
        }

        [Fact]
        public void Create_AddExcistingPassportNumber_Test()
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

            _repository.Setup(x => x.GetByPassportNumber(It.IsAny<string>())).Returns(customer);
            _customerService = new CustomerService(_repository.Object);

            Assert.Throws<PassportNumberConflictExceprion>(() =>  _customerService.CreateCustomer(customer));

        }

        [Fact]
        public void Update_CustomerSuccessfullyEdited_Test()
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

            _repository.Setup(x => x.Update(It.IsAny<Customer>())).Returns(customer);
            _customerService = new CustomerService(_repository.Object);

            var result = _customerService.UpdateCustomer(customer);

            Assert.Equal(DateTime.Today, result.LastEditDate);
        }

        [Fact]
        public void Update_CustomerIsNull_Test()
        {
            _repository.Setup(x => x.Update(It.IsAny<Customer>())).Returns<Customer>(null);
            _customerService = new CustomerService(_repository.Object);

            Assert.Throws<ArgumentNullException>(() => _customerService.UpdateCustomer(null));
        }

        [Fact]
        public void Update_CustomerNotFound_Test()
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

            _repository.Setup(x => x.Update(It.IsAny<Customer>())).Throws(new ArgumentOutOfRangeException());
            _customerService = new CustomerService(_repository.Object);

            Assert.Throws<CustomerNotFoundException>(() => _customerService.UpdateCustomer(customer));
        }

        [Fact]
        public void Get_IdIsNotExist_Test()
        {
            _repository.Setup(x => x.GetById(It.IsAny<int>())).Returns<Customer>(null);
            _customerService = new CustomerService(_repository.Object);

            Assert.Throws<CustomerNotFoundException>(() => _customerService.GetCustomer(1));
        }

    }
}
