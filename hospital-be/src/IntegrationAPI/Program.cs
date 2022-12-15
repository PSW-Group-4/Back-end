using HospitalLibrary.BloodSupplies.Model;
using IntegrationAPI.Communications.Consumer.ReceivedBlood;
using IntegrationAPI.Communications.Consumer.BloodBankNews;
using IntegrationAPI.Communications.Consumer.BloodRequestResponse;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IntegrationAPI.Communications.Consumer.BloodSubscriptionResponse;

namespace IntegrationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    services
                        .AddHostedService<BloodSubscriptionResponseListener>()
                        .AddHostedService<BloodListener>()
                        .AddHostedService<NewsListener>()
                        .AddHostedService<BloodRequestResponseListener>();
                });
    }
}