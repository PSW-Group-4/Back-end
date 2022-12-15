using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using HospitalLibrary.Renovation.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace HospitalAPI.HostedService
{
    public class FinishRenovationTask : BaseTaskScheduler
    {
        IRenovationAppointmentService _renovationService;
        public FinishRenovationTask(IServiceScopeFactory factory, ITaskSettings<FinishRenovationTask> config) : base(config.CronExpression, config.TimeZoneInfo)
        {
            _renovationService = factory.CreateScope().ServiceProvider.GetService<IRenovationAppointmentService>();
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            DoWork(cancellationToken);
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _renovationService.CheckForFinishedRenovations();
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}