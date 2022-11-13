using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBankNews.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntegrationApp.Setup;
using Xunit;

namespace TestIntegrationApp.IntegrationTesting
{
    public class NewsTests : BaseIntegrationTest
    {
        public NewsTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static NewsController SetupController(IServiceScope scope)
        {
            return new NewsController(scope.ServiceProvider.GetRequiredService<INewsService>());
        }

        [Fact]
        public void Retrieves_all_news()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<News>;

            Assert.NotNull(result);
        }
    }
}
