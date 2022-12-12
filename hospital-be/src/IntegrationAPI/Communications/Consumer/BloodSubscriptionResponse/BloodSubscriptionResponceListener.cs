using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using IntegrationLibrary.BloodSubscriptionResponses.Service;

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
                    IBloodSubscriptionResponseService responseService = scope.ServiceProvider.GetRequiredService<IBloodSubscriptionResponseService>();
                    IConsumer<Ignore, string> consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build();
                    {
                        consumerBuilder.Subscribe(topic);
                        CancellationTokenSource cancelToken = new();
                        BloodSubscriptionResponceConsumer consumer = new(consumerBuilder, cancelToken);
                        try
                        {
                            while (false)
                            {
                                //TODO: Update BloodSubscriptionResponse so it only consumes id and message simple 2 column table
                                IntegrationLibrary.BloodSubscriptionResponses.Model.BloodSubscriptionResponse response = consumer.Consume();
                                if(response != null)
                                {
                                    //"DELIVERY-SUCCESS:A_POSITIVE"
                                    if (response.Message.Split(":")[0].Equals("DELIVERY - SUCCESS"))
                                    {
                                        //TODO: fetch subscription, get its blood type and amount  
                                        //and update hospital blood supply
                                    }
                                    responseService.Create(response);
                                }
                                
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
