using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationAPI.Dtos.BloodBankNews;
using Microsoft.Extensions.DependencyInjection;
using IntegrationLibrary.BloodBankNews.Service;
using IntegrationAPI.Dtos;

namespace IntegrationAPI.Communications.Consumer.BloodBankNews
{
    public class NewsListener : IHostedService
    {
        private readonly string topic = "news.topic";
        private readonly string groupId = "news";
        private readonly string bootstrapServers = "localhost:9094";
        public IServiceScopeFactory _serviceScopeFactory;

        public NewsListener(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Started NewsListener");
            Task.Run(() => Listen(cancellationToken));

            return Task.CompletedTask;
        }

        public void Listen(CancellationToken cancellationToken)
        {
            ConsumerConfig config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try
            {
                using (IServiceScope scope = _serviceScopeFactory.CreateScope())
                {
                    INewsService newsService = scope.ServiceProvider.GetRequiredService<INewsService>();
                    var newsConverter = scope.ServiceProvider.GetRequiredService<IConverter<News, NewsDto>>();
                    IConsumer<Ignore, string> consumerBuilder = new ConsumerBuilder
                        <Ignore, string>(config).Build();
                    {
                        consumerBuilder.Subscribe(topic);
                        CancellationTokenSource cancelToken = new CancellationTokenSource();
                        NewsConsumer newsConsumer = new(consumerBuilder, cancelToken, newsConverter);
                        try
                        {
                            while (true)
                            {
                                News news = newsConsumer.Consume();
                                newsService.Save(news);
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
                Debug.WriteLine(ex.Message);
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
