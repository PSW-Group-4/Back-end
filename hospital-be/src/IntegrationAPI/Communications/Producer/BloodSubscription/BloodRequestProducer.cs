using IntegrationAPI.Dtos.BloodRequests;
using IntegrationLibrary.BloodRequests.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using IntegrationAPI.HostedServices;

namespace IntegrationAPI.Communications.Producer.BloodSubscription
{
    public class BloodRequestProducer : BaseTaskScheduler
    {
        private readonly string _topic = "blood.requests.topic";

        private readonly IBloodRequestService _requestService;
        public IServiceScopeFactory ServiceScopeFactory;
        public IProducer _producer;

        public BloodRequestProducer(IServiceScopeFactory factory, ITaskSettings<BloodRequestProducer> config) : base(config.CronExpression, config.TimeZoneInfo)
        {
            ServiceScopeFactory = factory;
            _requestService = ServiceScopeFactory.CreateScope().ServiceProvider.GetService<IBloodRequestService>();
            _producer = ServiceScopeFactory.CreateScope().ServiceProvider.GetService<IProducer>();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {

            foreach (var request in _requestService.GetAllUrgentApprovedNotSent())
            {
                try
                {
                    var dto = BloodRequestSendConverter.Convert(request);
                    _producer.Send(JsonSerializer.Serialize(dto), _topic);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
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
