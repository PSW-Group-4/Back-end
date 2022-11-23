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
                    INewsService newsService = scope.ServiceProvider.GetRequiredService<INewsService>();
                    var newsConverter = scope.ServiceProvider.GetRequiredService<IConverter<News, NewsDto>>();
                    IConsumer<Ignore, string> consumerBuilder = new ConsumerBuilder
                <Ignore, string>(config).Build();
                    {
                        consumerBuilder.Subscribe(topic);
                        CancellationTokenSource cancelToken = new CancellationTokenSource();
                        MyHumbleObject myHumbleObject = new MyHumbleObject(consumerBuilder, cancelToken, newsService, newsConverter);

                        try
                        {
                            while (true)
                            {
                                myHumbleObject.DoStuff();
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
