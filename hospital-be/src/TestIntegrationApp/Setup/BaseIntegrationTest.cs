using IntegrationAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestIntegrationApp.Setup
{
    public class BaseIntegrationTest : IClassFixture<TestDatabaseFactory<Startup>>
    {
        protected TestDatabaseFactory<Startup> Factory { get; }

        public BaseIntegrationTest(TestDatabaseFactory<Startup> factory)
        {
            Factory = factory;
        }
    }
}
