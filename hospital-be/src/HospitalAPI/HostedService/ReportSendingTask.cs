using HospitalLibrary.Appointments.Service;
using HospitalLibrary.MoveEquipment.Repository.Interfaces;
using HospitalLibrary.MoveEquipment.Service.Implementation;
using HospitalLibrary.MoveEquipment.Service.Interfaces;
using IntegrationLibrary.BloodReport.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalAPI.HostedService
{
    public class ReportSendingTask : BaseTaskScheduler
    {

        IMoveEquipmentAppointmentService _moveEquipmentTaskService;
        public ReportSendingTask(IServiceScopeFactory factory, ITaskSettings<ReportSendingTask> config) : base(config.CronExpression, config.TimeZoneInfo)
        {
            _moveEquipmentTaskService = factory.CreateScope().ServiceProvider.GetService<IMoveEquipmentAppointmentService>();
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            DoWork(cancellationToken);
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _moveEquipmentTaskService.MoveEquipment();
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
