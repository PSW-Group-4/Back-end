using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAPI.HostedServices
{
    public interface IBaseTaskScheduler : IHostedService, IDisposable
    {
        public Task ScheduleJob(CancellationToken cancellationToken);
        public Task DoWork(CancellationToken cancellationToken);
        public Task StartAsync(CancellationToken cancellationToken);
        public Task StopAsync(CancellationToken cancellationToken);
        public void Dispose();
    }
}
