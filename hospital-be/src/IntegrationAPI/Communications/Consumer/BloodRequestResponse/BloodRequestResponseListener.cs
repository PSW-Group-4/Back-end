using Confluent.Kafka;
using IntegrationAPI.Communications.Consumer.ReceivedBlood;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System;
using IntegrationLibrary.BloodRequests.Service;
using IntegrationLibrary.BloodRequests.Model;

namespace IntegrationAPI.Communications.Consumer.BloodRequestResponse
{
    public class BloodRequestResponseListener : IHostedService
    {
        private readonly string topic = "blood.requests.responses.topic";
        private readonly string groupId = "bloodRequestResponses";
        private readonly string bootstrapServers = "localhost:9094";
        public IServiceScopeFactory _serviceScopeFactory;

        public BloodRequestResponseListener(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Started BloodRequestResponseListener");
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
                    IBloodRequestService bloodRequestService = scope.ServiceProvider.GetRequiredService<IBloodRequestService>();
                    IConsumer<Ignore, string> consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
                    {
                        consumerBuilder.Subscribe(topic);
                        CancellationTokenSource cancelToken = new();
                        BloodRequestResponseConsumer consumer = new(consumerBuilder, cancelToken, bloodRequestService);
                        try
                        {
                            while (true)
                            {
                                BloodRequest response = consumer.Consume();
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
