using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.Tests.Tests
{
    public class TestCollectionOrderer : ITestCollectionOrderer
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TestCollectionOrderer(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
        {
            _testOutputHelper.WriteLine("OrderTestCollections Method at {0}", DateTime.Now);
            return testCollections.OrderBy(x => x.DisplayName);
        }
    }
}
