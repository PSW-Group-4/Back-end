using Confluent.Kafka;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BloodSupplies.Service;
using IntegrationAPI.Communications.Consumer.BloodSupplyConsumers;
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
                    IBloodRequestService bloodRequestService = scope.ServiceProvider.GetRequiredService<IBloodRequestService>();
                    IConsumer<Ignore, string> consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
                    {
                        consumerBuilder.Subscribe(topic);
                        CancellationTokenSource cancelToken = new CancellationTokenSource();
                        BloodRequestResponseConsumer consumer = new BloodRequestResponseConsumer(consumerBuilder, cancelToken, bloodRequestService);
                        try
                        {
                            while (true)
                            {
                                BloodRequest response = consumer.Consume();
                                bloodRequestService.Update(response);
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
