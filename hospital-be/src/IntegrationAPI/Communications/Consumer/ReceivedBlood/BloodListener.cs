using Confluent.Kafka;
using IntegrationAPI.Communications.Consumer.ReceivedBlood;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System;
using IntegrationAPI.Communications.Producer;
using IntegrationLibrary.Common;

namespace IntegrationAPI.Communications.Consumer.ReceivedBlood
{
    public class BloodListener : IHostedService
    {
        private readonly string _topic = "requested.blood.topic";
        private readonly string _groupId = "requestedBlood";
        private readonly string _bootstrapServers = "localhost:9094";
        public IServiceScopeFactory ServiceScopeFactory;

        public BloodListener(IServiceScopeFactory serviceScopeFactory)
        {
            ServiceScopeFactory = serviceScopeFactory;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Started BloodListener");
            Task.Run(() => Listen(cancellationToken));
            
            return Task.CompletedTask;
        }

        public void Listen(CancellationToken cancellationToken)
        {
            ConsumerConfig config = new()
            {
                GroupId = _groupId,
                BootstrapServers = _bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try
            {
                using (IServiceScope scope = ServiceScopeFactory.CreateScope())
                {
                    IProducer producer = scope.ServiceProvider.GetRequiredService<IProducer>();
                    IConsumer<Ignore, string> consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
                    {
                        consumerBuilder.Subscribe(_topic);
                        CancellationTokenSource cancelToken = new();
                        BloodConsumer bloodConsumer = new(consumerBuilder, cancelToken, producer);
                        try
                        {
                            while (true)
                            {
                                Blood receivedBlood = bloodConsumer.Consume();
                                if (cancellationToken.IsCancellationRequested)
                                    break;
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
