using CQRSwithBDD.Data;
using CQRSwithBDD.DomainModel;
using CQRSwithBDD.Repositories;
using System;
using Xunit;

namespace CQRSwithBDDtest
{
    public class UnitTest1
    {
        [Fact]
        public void AddCustomerToESAsync_Should_Return_InsertedCustomer()
        {
            //Test should be done in fake db.
            var customer = new Customer("TestName","TestFamily",DateTime.Now
                ,"+989384xxxx29","test@test.com","ISA123456789");
            var dbContext = new CustomerDbContext();
            var repository = new CustomerRepository(dbContext);

            var result = repository.AddCustomerToESAsync(customer);

            Assert.NotNull(result);
        }
        [Fact]
        public void AddCustomer_With_DuplicateFirstnameAndLasnameAndBirthDate_Should_throw_Exception()
        {
            var customer = new Customer("fname", "lname", new DateTime(2022, 4, 9, 14, 20, 42, 461, DateTimeKind.Local).AddTicks(502)
                , "+989384xxxx29", "test@test.com", "ISA123456789");

            var dbContext = new CustomerDbContext();
            var repository = new CustomerRepository(dbContext);
            var exception = Assert.ThrowsAny<Exception>(() => repository.AddCustomerToESAsync(customer).GetAwaiter().GetResult());
            Assert.Equal("There is a customer with this FirstName and LstName and DateOfBirth", exception.Message);

        }
    }
}
