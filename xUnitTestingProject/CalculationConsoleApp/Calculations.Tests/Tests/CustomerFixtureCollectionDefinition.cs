using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculations.Tests.Tests.FixtureCollectionsConfig
{
    [CollectionDefinition("Customer")]
    class CustomerFixtureCollectionDefinition : ICollectionFixture<CustomerFixture>
    {
    }
}
