using Confluent.Kafka;
using IntegrationAPI.Dtos.BloodBankNews;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBankNews.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BloodSupplies.Service;
using IntegrationAPI.Communications.Producer;
using IntegrationAPI.Dtos.BloodSupplies;
using IntegrationLibrary.Common;

namespace IntegrationAPI.Communications.Consumer.ReceivedBlood
{
    public class BloodListener : IHostedService
    {
        private readonly string topic = "requested.blood.topic";
        private readonly string groupId = "requestedBlood";
        private readonly string bootstrapServers = "localhost:9094";
        public IServiceScopeFactory _serviceScopeFactory;

        public BloodListener(IServiceScopeFactory serviceScopeFactory)
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
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    IConsumer<Ignore, string> consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
                    {
                        IProducer producer = scope.ServiceProvider.GetRequiredService<IProducer>();
                        consumerBuilder.Subscribe(topic);
                        CancellationTokenSource cancelToken = new CancellationTokenSource();
                        BloodConsumer bloodConsumer = new(consumerBuilder, cancelToken, producer);
                        try
                        {
                            while (true)
                            {
                                Blood receivedBlood = bloodConsumer.Consume();
                                Console.WriteLine("Received blood!");
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

            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

}
