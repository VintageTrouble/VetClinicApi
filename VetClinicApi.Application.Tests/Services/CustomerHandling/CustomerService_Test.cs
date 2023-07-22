using Moq;

using VetClinicApi.Application.Services.CustomerHandlig;
using VetClinicApi.Core.Entities;
using VetClinicApi.Database.Repositories;

using Xunit;

namespace VetClinicApi.Application.Tests.Services.CustomerHandling
{
    public class Test
    {
        private CustomerService _customerService;
        private Mock<IAbstractRepository<Customer>> _repository = new Mock<IAbstractRepository<Customer>>();


        [Fact]
        public void CreateCustomer_ValidPerson_Test()
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
            Customer customer = null;
            _repository.Setup(x => x.Add(It.IsAny<Customer>())).Returns(customer);
            _customerService = new CustomerService(_repository.Object);
            Assert.Throws<ArgumentNullException>(() => _customerService.UpdateCustomer(null));
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
            Customer customer = null;
            _repository.Setup(x => x.Update(It.IsAny<Customer>())).Returns(customer);
            _customerService = new CustomerService(_repository.Object);
            Assert.Throws<ArgumentNullException>(() => _customerService.UpdateCustomer(null));
        }

    }
}
