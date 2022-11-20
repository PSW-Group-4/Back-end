using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using IntegrationAPI.Dtos;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationAPI.Dtos.BloodBankNews;
using Microsoft.Extensions.DependencyInjection;
using IntegrationLibrary.BloodBankNews.Service;

namespace IntegrationAPI.Communications
{
    public class NewsConsumer : IHostedService
    {
        private readonly string topic = "news.topic";
        private readonly string groupId = "news";
        private readonly string bootstrapServers = "localhost:9094";
        public IServiceScopeFactory _serviceScopeFactory;

        public NewsConsumer(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try
            {
                using(var scope = _serviceScopeFactory.CreateScope())
                {
                    var newsService = scope.ServiceProvider.GetRequiredService<INewsService>();
                    var newsConverter = scope.ServiceProvider.GetRequiredService<IConverter<News, NewsDto>>();
                    using (var consumerBuilder = new ConsumerBuilder
                <Ignore, string>(config).Build())
                    {
                        consumerBuilder.Subscribe(topic);
                        var cancelToken = new CancellationTokenSource();

                        try
                        {
                            while (false)
                            {
                                var consumer = consumerBuilder.Consume(cancelToken.Token);
                                NewsDto newsDto = JsonSerializer.Deserialize<NewsDto>(consumer.Message.Value);
                                newsService.Save(newsConverter.Convert(newsDto));
                                Console.WriteLine("Consumed: " + newsDto);
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            consumerBuilder.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
