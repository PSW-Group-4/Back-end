using Confluent.Kafka;
using IntegrationAPI.Dtos.BloodSubscription;
using IntegrationAPI.HostedServices;
using IntegrationLibrary.BloodSubscriptions.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAPI.Communications.Producer.BloodSubscription
{
    public class SubscriptionScheduler : BaseTaskScheduler
    {
        private readonly string _topic = "blood.subscriptions.topic";

        private readonly IBloodSubscriptionService _subscriptionService;
        public IServiceScopeFactory ServiceScopeFactory;
        public SubscriptionScheduler(IServiceScopeFactory factory, ITaskSettings<SubscriptionScheduler> config) : base(config.CronExpression, config.TimeZoneInfo)
        {
            ServiceScopeFactory = factory;
            _subscriptionService = ServiceScopeFactory.CreateScope().ServiceProvider.GetService<IBloodSubscriptionService>();
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            using (IServiceScope scope = ServiceScopeFactory.CreateScope())
            {
                IProducer producer = scope.ServiceProvider.GetRequiredService<IProducer>();
                foreach (var subscription in _subscriptionService.GetActiveNotSent())
                {
                    try
                    {
                        BloodSubscriptionSendingDto dto = SubscriptionConverter.Convert(subscription);
                        producer.Send(JsonSerializer.Serialize(dto), _topic);
                        subscription.MakeSent();
                        _subscriptionService.Update(subscription);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

            }

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
