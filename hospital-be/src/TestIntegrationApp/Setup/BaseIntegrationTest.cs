using IntegrationAPI;
using Xunit;

namespace TestIntegrationApp.Setup
{
    public class BaseIntegrationTest : IClassFixture<TestDatabaseFactory<Startup>>
    {
        public BaseIntegrationTest(TestDatabaseFactory<Startup> factory)
        {
            Factory = factory;
        }

        protected TestDatabaseFactory<Startup> Factory { get; }
    }
}