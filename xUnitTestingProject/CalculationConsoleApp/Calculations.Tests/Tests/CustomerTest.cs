using CalculationConsoleApp.Services;
using System;
using Xunit;

namespace Calculations.Tests.Tests
{

    [Collection("Customer")]
    public class CustomerTest : IClassFixture<CustomerFixture>
    {
        private readonly CustomerFixture _customerFixture;

        public CustomerTest(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        [Trait("Category", "Customer")]
        public void CheckNameNotEmpty()
        {
            var customer = _customerFixture.Customer;
            Assert.NotNull(customer.Name);
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        [Fact]
        [Trait("Category", "Customer")]
        public void CheckLegibilityForDiscount()
        {
            var customer = _customerFixture.Customer;
            Assert.InRange(customer.Age, 25, 35);
        }

        [Fact]
        [Trait("Category", "Customer")]
        public void ThrowArgumentException_WhenGetOrderByNullName()
        {
            var customer = _customerFixture.Customer;
            var ex = Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(null));
            Assert.Equal("Null Name", ex.Message);
        }

        [Fact]
        [Trait("Category", "Customer")]
        public void returnNameLength_WhenGetOrderByName()
        {
            var name = "Rafael";

            var customer = _customerFixture.Customer;
            var result = customer.GetOrdersByName(name);
            Assert.Equal(name.Length, result);
        }

        [Fact]
        [Trait("Category", "Customer")]
        public void CreateLoyalCustomerForOrdersGreaterThan100()
        {
            var customer = CustomerFactory.CreateCustomerInstance(110);
            var c = Assert.IsType<LoyalCustomer>(customer);
            Assert.Equal(10, c.Discount);
        }

        [Fact]
        [Trait("Category", "Customer")]
        public void CreateRegularCustomerForOrdersLessThan101()
        {
            var customer = CustomerFactory.CreateCustomerInstance(100);
            var c = Assert.IsType<Customer>(customer);
            Assert.Equal(4, c.GetOrdersByName("Name"));
        }
    }
}
