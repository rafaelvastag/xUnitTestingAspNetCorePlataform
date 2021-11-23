using CalculationConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculations.Tests.Tests
{
    public class CustomerTest
    {

        [Fact]
        public void CheckNameNotEmpty()
        {
            var customer = new Customer();
            Assert.NotNull(customer.Name);
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        [Fact]
        public void CheckLegibilityForDiscount()
        {
            var customer = new Customer();
            Assert.InRange(customer.Age, 25, 35);
        }

        [Fact]
        public void ThrowArgumentException_WhenGetOrderByNullName()
        {
            var customer = new Customer();
            var ex = Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(null));
            Assert.Equal("Null Name", ex.Message);
        }

        [Fact]
        public void returnNameLength_WhenGetOrderByName()
        {
            var name = "Rafael";

            var customer = new Customer();
            var result = customer.GetOrdersByName(name);
            Assert.Equal(name.Length, result);
        }

        [Fact]
        public void CreateLoyalCustomerForOrdersGreaterThan100()
        {
            var customer = CustomerFactory.CreateCustomerInstance(110);
            var c = Assert.IsType<LoyalCustomer>(customer);
            Assert.Equal(10, c.Discount);
        }

        [Fact]
        public void CreateRegularCustomerForOrdersLessThan101()
        {
            var customer = CustomerFactory.CreateCustomerInstance(100);
            var c = Assert.IsType<Customer>(customer);
            Assert.Equal(4, c.GetOrdersByName("Name"));
        }
    }
}
