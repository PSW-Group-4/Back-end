using Confluent.Kafka;
using IntegrationAPI.Dtos.BloodBankNews;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBankNews.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.Extensions.Hosting;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BloodSupplies.Service;

namespace IntegrationAPI.Communications.Consumer
{
    public class BloodSupplyListener : IHostedService
    {
        private readonly string topic = "blood.supply.topic";
        private readonly string groupId = "bloodSupplies";
        private readonly string bootstrapServers = "localhost:9094";
        public IServiceScopeFactory _serviceScopeFactory;

        public BloodSupplyListener(IServiceScopeFactory serviceScopeFactory)
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
                    IBloodSupplyService bloodSupplyService = scope.ServiceProvider.GetRequiredService<IBloodSupplyService>();
                    IConsumer<Ignore, string> consumerBuilder = new ConsumerBuilder
                <Ignore, string>(config).Build();
                    {
                        consumerBuilder.Subscribe(topic);
                        CancellationTokenSource cancelToken = new CancellationTokenSource();
                        BloodSupplyConsumer bloodSupplyConsumer = new(consumerBuilder, cancelToken);
                        try
                        {
                            while (true)
                            {
                                BloodSupply bloodSupply = bloodSupplyConsumer.Consume();
                                bloodSupplyService.Create(bloodSupply);
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
