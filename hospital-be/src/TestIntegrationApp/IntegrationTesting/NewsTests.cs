using IntegrationAPI;
using IntegrationAPI.Communications.Consumer;
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
            News news = new News(Guid.NewGuid(), null, "It's me, hi", "I'm the news, it's me", DateTime.Now, false);
            
            using var scope = Factory.Services.CreateScope();
            var service = SetupService(scope);
            service.Save(news);

            var result = service.GetAll();
            Assert.NotEmpty(result);

        }
        [Fact]
        public void Update_News() 
        {
            News news = new News(Guid.NewGuid(), null, "It's me, hi", "I'm the news, it's me", DateTime.Now, false);

            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            var service = SetupService(scope);
            service.Save(news);
            var allNews = ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<News>;
            News updatedNews = allNews.ElementAt(0);
            var result = controller.ArchiveNews(updatedNews.Id.ToString());
            Assert.True((((OkObjectResult)result)?.Value as News).IsArchived);
        }
        [Fact]
        public void Get_Archived()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            bool success = true;
            var result = ((OkObjectResult)controller.GetArchived())?.Value as IEnumerable<News>;
            if (result != null)
                foreach (News news in result)
                {
                    success = success && news.IsArchived;
                }
            else success = false;
            Assert.True(success);
        }
        [Fact]
        public void Get_Published()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            bool success = true;
            var result = ((OkObjectResult)controller.GetArchived())?.Value as IEnumerable<News>;
            if (result != null)
                foreach (News news in result)
                {
                    success = success && news.IsPublished;
                }
            else success = false;
            Assert.True(success);
        }
        [Fact]
        public void Get_Pending()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            bool success = true;
            var result = ((OkObjectResult)controller.GetPending())?.Value as IEnumerable<News>;
            if (result != null)
                foreach (News news in result)
                {
                    success = success && !news.IsPublished && !news.IsArchived;
                }
            else success = false;
            Assert.True(success);
        }

        [Fact]
        public void Consumes_News()
        {
            News news = new News(Guid.NewGuid(), null, "It's me, hi", "I'm the news, it's me", DateTime.Now, false);

            var consumerMock = new Mock<IConsumer<News>>();
            consumerMock.Setup(consumer => consumer.Consume()).Returns(news);

            using var scope = Factory.Services.CreateScope();
            var service = SetupService(scope);
            IConsumer<News> consumer = consumerMock.Object;
            service.Save(consumer.Consume());

            var result = service.GetAll();
            Assert.Contains(result, expectedNews => expectedNews.Id == news.Id);
        }
    }
}
