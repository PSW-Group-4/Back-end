﻿using IntegrationAPI.Communications;
using IntegrationLibrary.BloodReport.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

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
            //TODO Implement some funcitonality
            //Console.WriteLine(DateTime.Now.ToString());
            //var retVal = _reportService.Create("32db7839-f8a4-4c8b-9486-80f783ed6746");
            //PdfSender.SendPdf(IntegrationLibrary.Settings.PdfSenderResources.isaUrl, retVal.ReportPath);
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}