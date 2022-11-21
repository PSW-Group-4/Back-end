using System;

namespace IntegrationAPI.HostedServices
{
    public class ITaskSettings <T>
    {
        public string CronExpression { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
