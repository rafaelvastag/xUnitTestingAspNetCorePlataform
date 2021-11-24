using Xunit;

namespace Calculations.Tests.Tests
{
    [Collection("Customer")]
    public class CustomerDetailsTest : IClassFixture<CustomerFixture>
    {
        private readonly CustomerFixture _customerFixture;

        public CustomerDetailsTest(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        [Trait("Category", "CustomerDetails")]
        public void GetFullName_GivenFirstAndLastName()
        {
            var customer = _customerFixture.Customer;
            Assert.Equal("Rafael Vastag", customer.GetCustomerFullName("Rafael", "Vastag"));
        }
    }
}
