using Confluent.Kafka;
using IntegrationAPI.Communications.Producer;
using IntegrationAPI.Dtos.BloodSubscription;
using IntegrationAPI.Dtos.BloodSupplies;
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
using IntegrationAPI.Dtos.BloodSubscriptionResponse;
using IntegrationLibrary.BloodSubscriptionResponses.Service;

namespace IntegrationAPI.Communications.Consumer.BloodSubscriptionResponse
{
    public class BloodSubscriptionResponseListener : IHostedService
    {
       
        private readonly string topic = "blood.subscriptions.response.topic";
        private readonly string groupId = "bloodSubscriptionResponses";
        private readonly string bootstrapServers = "localhost:9094";
        public IServiceScopeFactory _serviceScopeFactory;
        public BloodSubscriptionResponseListener(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Started BloodSubscriptionResponseListener");
            Task.Run(() => Listen(cancellationToken));
            
            return Task.CompletedTask;
        }

        public void Listen(CancellationToken cancellationToken)
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
                    IBloodSubscriptionResponseService responseService = scope.ServiceProvider.GetRequiredService<IBloodSubscriptionResponseService>();
                    IBloodSubscriptionService subscriptionService = scope.ServiceProvider.GetRequiredService<IBloodSubscriptionService>();
                    IConsumer<Ignore, string> consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
                    {
                        IProducer producer = scope.ServiceProvider.GetRequiredService<IProducer>();
                        consumerBuilder.Subscribe(topic);
                        CancellationTokenSource cancelToken = new();
                        BloodSubscriptionResponseConsumer consumer = new(consumerBuilder, cancelToken, producer,subscriptionService,responseService);
                        try
                        {
                            while (true)
                            {
                                BloodSubscriptionResponseDto response = consumer.Consume(); 
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
