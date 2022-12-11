using Confluent.Kafka;
using IntegrationAPI.Communications.Producer;
using IntegrationAPI.Dtos.BloodSubscription;
using IntegrationAPI.Dtos.BloodSubscriptionResponce;
using IntegrationAPI.Dtos.BloodSupplies;
using IntegrationLibrary.BloodSubscriptionReponces.Model;
using IntegrationLibrary.BloodSubscriptionReponces.Service;
using IntegrationLibrary.BloodSubscriptions;
using IntegrationLibrary.BloodSubscriptions.Service;
using IntegrationLibrary.Common;
using IntegrationLibrary.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAPI.Communications.Consumer.BloodSubscriptionResponse
{
    public class BloodSubscriptionResponceListener : IHostedService
    {
       
        private readonly string topic = "blood.subscriptions.responce.topic";
        private readonly string groupId = "bloodSubscriptionResponses";
        private readonly string bootstrapServers = "localhost:9094";
        public IServiceScopeFactory _serviceScopeFactory;
        public BloodSubscriptionResponceListener(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ConsumerConfig config = new()
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try
            {
                using (IServiceScope scope = _serviceScopeFactory.CreateScope())
                {
                    IBloodSubscriptionResponceService responceService = scope.ServiceProvider.GetRequiredService<IBloodSubscriptionResponceService>();
                    IBloodSubscriptionService subscriptionService = scope.ServiceProvider.GetRequiredService<IBloodSubscriptionService>();
                    IConsumer<Ignore, string> consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
                    {
                        IProducer producer = scope.ServiceProvider.GetRequiredService<IProducer>();
                        consumerBuilder.Subscribe(topic);
                        CancellationTokenSource cancelToken = new();
                        BloodSubscriptionResponceConsumer consumer = new(consumerBuilder, cancelToken, producer,subscriptionService,responceService);
                        try
                        {
                            while (true)
                            {
                                //TODO: Update BloodSubscriptionRepsponce so it only consumes id and message simple 2 column table
                                BloodSubscriptionResponceDto response = consumer.Consume(); 
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
