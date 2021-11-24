using CalculationConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculations.Tests.Tests
{
    public class NamesTest
    {
        [Fact]
        [Trait("Category", "NamesHandler")]
        public void ShouldReturnsFullNameTest()
        {
            NamesBuilder n = new NamesBuilder();

            var result = n.MakeFullName("Rafael", "Vastag");


            Assert.IsType<string>(result);
            Assert.Equal("Rafael Vastag", result);
            Assert.Contains("Rafael", result); // case sensitive
            Assert.Contains("rafael", result, StringComparison.InvariantCultureIgnoreCase); // NOT case sensitive
            Assert.StartsWith("Rafael", result); // case sensitive
            Assert.EndsWith("Vastag", result); // case sensitive
            Assert.EndsWith("Vastag", result, StringComparison.InvariantCultureIgnoreCase); // NOT case sensitive
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", result);
        }

        [Fact]
        [Trait("Category", "NamesHandler")]
        public void MakeFullName_AlwaysReturnValue()
        {
            NamesBuilder n = new NamesBuilder();

            var result = n.MakeFullName("Rafael", "Vastag");

            Assert.IsType<string>(result);
            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result));
        }

        [Fact]
        [Trait("Category", "NamesHandler")]
        public void NickName_MustBeNull()
        {
            NamesBuilder n = new NamesBuilder();
            Assert.Null(n.NickName);
        }

        [Fact]
        [Trait("Category", "NamesHandler")]
        public void NickName_MustBeNotNull()
        {
            NamesBuilder n = new NamesBuilder();
            n.NickName = "Strong Name";
            Assert.IsType<string>(n.NickName);
            Assert.NotNull(n.NickName);
        }
    }
}
