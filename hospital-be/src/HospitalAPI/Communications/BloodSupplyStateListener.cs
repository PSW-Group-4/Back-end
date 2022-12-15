using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BloodSupplies.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HospitalAPI.Communications
{
    public class BloodSupplyStateListener: IHostedService
    {
        private readonly string topic = "hospital.blood.supply.topic";
        private readonly string groupId = "hospitalBlood";
        private readonly string bootstrapServers = "localhost:9094";
        public IServiceScopeFactory _serviceScopeFactory;

        public BloodSupplyStateListener(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Started BloodSupplyStateListener");
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
                    IConsumer<Ignore, string> consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
                    {
                        consumerBuilder.Subscribe(topic);
                        IBloodSupplyService bloodSupplyService = scope.ServiceProvider.GetRequiredService<IBloodSupplyService>();
                        CancellationTokenSource cancelToken = new CancellationTokenSource();
                        BloodSupplyStateConsumer bloodSupplyConsumer = new(consumerBuilder, cancelToken, bloodSupplyService);
                        try
                        {
                            while (true)
                            {
                                BloodSupply bloodSupply = bloodSupplyConsumer.Consume();
                                Console.WriteLine("Hospital received blood!");
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