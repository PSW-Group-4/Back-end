using IntegrationAPI;
using IntegrationAPI.Communications;
using IntegrationAPI.Controllers;
using IntegrationAPI.Dtos;
using IntegrationAPI.Dtos.BloodBankNews;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBankNews.Repository;
using IntegrationLibrary.BloodBankNews.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
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

        private static NewsService SetupService(IServiceScope scope)
        {
            return new NewsService(scope.ServiceProvider.GetRequiredService<INewsRepository>());
        }

        [Fact]
        public void Retrieves_all_news()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);

            var result = ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<News>;

            Assert.NotNull(result);
        }

        [Fact]
        public void Saves_News()
        {
            News news = new()
            {
                Id = Guid.NewGuid(),
                Title = "It's me, hi",
                Body = "I'm the news, it's me",
                Timestamp = DateTime.Now,
                BloodBank = null,
                IsArchived = false,
                IsPublished = false
            };
            using var scope = Factory.Services.CreateScope();
            var service = SetupService(scope);
            service.Save(news);

            var result = service.GetAll();
            Assert.NotEmpty(result);

        }

        [Fact]
        public void Consumes_News()
        {
            News news = new()
            {
                Id = Guid.NewGuid(),
                Title = "It's me, hi",
                Body = "I'm the news, it's me",
                Timestamp = DateTime.Now,
                BloodBank = null,
                IsArchived = false,
                IsPublished = false
            };
            var consumerMock = new Mock<IConsumer<News>>();
            consumerMock.Setup(consumer => consumer.Consume()).Returns(news);

            using var scope = Factory.Services.CreateScope();
            var service = SetupService(scope);
            service.Save(news);

            var result = service.GetAll();
            Assert.Contains(result, expectedNews => expectedNews.Id == news.Id);
        }
    }
}
