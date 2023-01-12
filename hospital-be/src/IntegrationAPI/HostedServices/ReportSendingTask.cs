using IntegrationAPI.Communications.Pdf;
using IntegrationLibrary.BloodReport.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using IntegrationLibrary.BloodReport.Model;
using IntegrationLibrary.Utilities;
using MimeKit;

namespace IntegrationAPI.HostedServices
{
    public class ReportSendingTask : BaseTaskScheduler
    {
        private readonly IBbReportService _reportService;
        public ReportSendingTask(IServiceScopeFactory factory, ITaskSettings<ReportSendingTask> config) : base(config.CronExpression, config.TimeZoneInfo)
        {
            _reportService = factory.CreateScope().ServiceProvider.GetService<IBbReportService>();
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {

            //var retVal = _reportService.Create("32db7839-f8a4-4c8b-9486-80f783ed6746");
            //PdfSender.SendPdf(IntegrationLibrary.Settings.PdfSenderResources.isaUrl, retVal.ReportPath);
            var retVal = _reportService.CreateAllTimeElapsed();
            foreach(ReportPathTransporter report in retVal)
            {
                
                PdfSender.SendPdf(IntegrationLibrary.Settings.PdfSenderResources.isaUrl, report.ReportPath);
                byte[] attachment = EmailSending.CreateEmailAttachment(report.ReportPath);
                MimeMessage email = EmailSending.CreateAttachedEmail(report.Report.BloodBank.Name, report.Report.BloodBank.EmailAddress, "Blood usage report", "Here is your blood usage report on the day:"+DateTime.Now.ToString(), "bloodReport"+ DateTime.Now.ToString()+ ".pdf", attachment);
                EmailSending.SendEmail(email);
            }
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
