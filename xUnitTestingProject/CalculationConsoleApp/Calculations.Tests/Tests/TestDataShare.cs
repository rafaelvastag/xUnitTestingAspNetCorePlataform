using System;
using System.Collections.Generic;
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
    }
}
