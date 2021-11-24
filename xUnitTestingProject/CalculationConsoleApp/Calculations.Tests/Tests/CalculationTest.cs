using CalculationConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.Tests.Tests
{
    public class CalculatorFixture
    {
        public CalculatorImpl CalcInstance => new CalculatorImpl();

    }

    public class CalculationTest : IClassFixture<CalculatorFixture>, IDisposable
    {

        private readonly CalculatorFixture _calculatorFixture;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly MemoryStream memoryStream;

        public CalculationTest(CalculatorFixture calculatorFixture, ITestOutputHelper testOutputHelper)
        {

            _calculatorFixture = calculatorFixture;
            _testOutputHelper = testOutputHelper;
            memoryStream = new MemoryStream();

            _testOutputHelper.WriteLine("Constructor Method at {0}", DateTime.Now);
        }

        [Fact]
        [Trait("Category", "Calculator")]
        public void AddTest_GivenTwoIntValues_ShouldReturnsInt()
        {
            Calculator c = _calculatorFixture.CalcInstance;
            var result = c.Add(1, 2);

            Assert.IsType<int>(result);
            Assert.Equal(3, result);
        }

        [Fact]
        [Trait("Category", "Calculator")]
        public void AddTest_GivenTwoDoubleValues_ShouldReturnsDouble()
        {
            Calculator c = _calculatorFixture.CalcInstance;
            var result = c.AddDouble(1.0, 2.5);

            Assert.IsType<double>(result);
            Assert.Equal(3.5, result);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesNotIncludeZero()
        {
            CalculatorImpl c = _calculatorFixture.CalcInstance;
            Assert.All(c.FiboNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesNotInclude4()
        {
            CalculatorImpl c = _calculatorFixture.CalcInstance;
            Assert.DoesNotContain(4, c.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesInclude13()
        {
            CalculatorImpl c = _calculatorFixture.CalcInstance;
            Assert.Contains(13, c.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckFiboCollection()
        {

            _testOutputHelper.WriteLine("CheckFiboCollection .. Starting test at {0}", DateTime.Now);

            var expectedResult = new List<int> { 1, 1, 2, 3, 5, 6, 13 };
            CalculatorImpl c = _calculatorFixture.CalcInstance;
            Assert.Equal(c.FiboNumbers, expectedResult);
        }

        [Theory]
        [Trait("Category", "Numbers")]
        [InlineData(1,true)]
        [InlineData(200, false)]
        public void IsOdd_TestOddOrEvenInlineDataProvider(int value, bool expected)
        {
            _testOutputHelper.WriteLine($"IsOdd_TestOddOrEvenInlineDataProvider : value = {value} , expected = {expected}");
            var c = _calculatorFixture.CalcInstance;
            var result = c.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "Numbers")]
        [MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddOrEvenSharedDataProvider(int value, bool expected)
        {
            _testOutputHelper.WriteLine($"IsOdd_TestOddOrEvenSharedDataProvider : value = {value} , expected = {expected}");
            var c = _calculatorFixture.CalcInstance;
            var result = c.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "Numbers")]
        [MemberData(nameof(TestDataShare.IsOddOrEvenExternal), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddOrEvenExternalDataProvider(int value, bool expected)
        {
            _testOutputHelper.WriteLine($"IsOdd_TestOddOrEvenExternalDataProvider : value = {value} , expected = {expected}");
            var c = _calculatorFixture.CalcInstance;
            var result = c.IsOdd(value);
            Assert.Equal(expected, result);
        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("Dispose Method at {0}", DateTime.Now);
            memoryStream.Close();
        }
    }
}
