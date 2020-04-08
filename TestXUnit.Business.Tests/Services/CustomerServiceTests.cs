using System;
using Bogus;
using Bogus.DataSets;
using Moq;
using Moq.AutoMock;
using TestXUnit.Business.Model;
using TestXUnit.Business.Repositories;
using TestXUnit.Business.Services;
using Xunit;

namespace TestXUnit.Business.Tests.Services
{
    [Trait("Category", "Customer Service Tests")]
    public class CustomerServiceTests
    {

        private readonly CustomerService _customerService;
        public AutoMocker Mocker;

        public CustomerServiceTests()
        {
            Mocker = new AutoMocker();
            _customerService = Mocker.CreateInstance<CustomerService>();
        }

        [Fact(DisplayName = "Add Customer with Success")]
        
        public void CustomerService_Add_ShouldRunSuccessfully()
        {
            // Arrange
            var customer = GenerateCustomerValid();

            // Act
            _customerService.Add(customer);

            // Assert
            Assert.True(customer.IsValid());
            Mocker.GetMock<ICustomerRepository>().Verify(r => r.Add(customer), Times.Once);
        }

        [Fact(DisplayName = "Add Customer with Fail")]
        public void CustomerService_Add_ShouldFail()
        {
            // Arrange
            var customer = GenerateCustomerInValid();

            // Act
            _customerService.Add(customer);

            // Assert
            Assert.False(customer.IsValid());
            Mocker.GetMock<ICustomerRepository>().Verify(r => r.Add(customer), Times.Never);
        }


        public Customer GenerateCustomerValid()
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var customer = new Faker<Customer>()
                .CustomInstantiator(f => new Customer(
                    Guid.NewGuid(), 
                    f.Name.FirstName(gender),
                    f.Name.LastName(gender),
                    DateTime.Now,
                    f.Person.Email
                    ));

            return customer;

        }


        public Customer GenerateCustomerInValid()
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var customer = new Faker<Customer>()
                .CustomInstantiator(f => new Customer(
                    Guid.NewGuid(),
                    f.Name.FirstName(gender),
                    f.Name.LastName(gender),
                    DateTime.Now,
                    null
                ));

            return customer;

        }

    }
}