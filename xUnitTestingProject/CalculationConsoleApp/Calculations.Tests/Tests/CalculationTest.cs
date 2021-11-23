using CalculationConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculations.Tests.Tests
{
    public class CalculationTest
    {
        [Fact]
        public void AddTest_GivenTwoIntValues_ShouldReturnsInt()
        {
            Calculator c = new CalculatorImpl();
            var result = c.Add(1, 2);

            Assert.IsType<int>(result);
            Assert.Equal(3,result);
        }

        [Fact]
        public void AddTest_GivenTwoDoubleValues_ShouldReturnsDouble()
        {
            Calculator c = new CalculatorImpl();
            var result = c.AddDouble(1.0, 2.5);

            Assert.IsType<double>(result);
            Assert.Equal(3.5, result);
        }

        [Fact]
        public void FiboDoesNotIncludeZero()
        {
            CalculatorImpl c = new CalculatorImpl();
            Assert.All(c.FiboNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        public void FiboDoesNotInclude4()
        {
            CalculatorImpl c = new CalculatorImpl();
            Assert.DoesNotContain(4, c.FiboNumbers);
        }

        [Fact]
        public void FiboDoesInclude13()
        {
            CalculatorImpl c = new CalculatorImpl();
            Assert.Contains(13, c.FiboNumbers);
        }

        [Fact]
        public void CheckFiboCollection()
        {
        var expectedResult = new List<int> { 1, 1, 2, 3, 5, 6, 13 };
        CalculatorImpl c = new CalculatorImpl();
            Assert.Equal(c.FiboNumbers, expectedResult);
        }

    }
}
