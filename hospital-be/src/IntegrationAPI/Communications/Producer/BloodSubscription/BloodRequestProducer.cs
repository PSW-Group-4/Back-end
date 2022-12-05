using IntegrationLibrary.BloodRequests.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAPI.Communications.Producer.BloodSubscription
{
    public class BloodRequestProducer : IHostedService
    {
        private readonly string _topic = "blood.subscriptions.topic";
 
        public IServiceScopeFactory ServiceScopeFactory;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                using (IServiceScope scope = ServiceScopeFactory.CreateScope())
                {
                    IProducer producer = scope.ServiceProvider.GetRequiredService<IProducer>();
                    IBloodRequestService _requestService = scope.ServiceProvider.GetService<IBloodRequestService>();

                    foreach (var requests in _requestService.GetAll()) // change this 
                    {
                        try
                        {
                            // convert to DTO
                            // serialise and send
                            //producer.Send(JsonSerializer.Serialize(dto), _topic);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.ToString());
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
