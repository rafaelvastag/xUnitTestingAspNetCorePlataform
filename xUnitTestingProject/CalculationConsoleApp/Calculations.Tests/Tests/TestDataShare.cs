using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations.Tests.Tests
{
    public static class TestDataShare
    {
        public static IEnumerable<object[]> IsOddOrEvenData
        {
            get
            {
                yield return new object[] { 1 , true};
                yield return new object[] { 200, false };
            }
        }

        public static IEnumerable<object[]> IsOddOrEvenExternal
        {
            get
            {
                var allLines = File.ReadAllLines("C:/Users/rgvas/Desktop/CoreEssentials/xUnitTestingProject/xUnitTestingProject/CalculationConsoleApp/Calculations.Tests/Tests/IsOddOrEvenTestData.txt");
                return allLines.Select( x =>
                {
                    var lineSplited = x.Split(',');
                    return new object[] { int.Parse(lineSplited[0]), bool.Parse(lineSplited[1]) };
                });
            }
        }
    }
}
