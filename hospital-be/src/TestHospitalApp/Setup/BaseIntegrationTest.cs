using HospitalAPI;
using Xunit;

namespace TestHospitalApp.Setup
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
