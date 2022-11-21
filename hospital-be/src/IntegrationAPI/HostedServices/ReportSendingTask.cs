using IntegrationLibrary.BloodReport.Service;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAPI.HostedServices
{
    public class ReportSendingTask : BaseTaskScheduler
    {
        private readonly IBbReportService _reportService;
        public ReportSendingTask(IBbReportService reportService, string cronExpression, TimeZoneInfo timeZoneInfo) : base(cronExpression, timeZoneInfo)
        {
            _reportService = reportService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            //TODO Implement some funcitonality
            Console.WriteLine(DateTime.Now);
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
