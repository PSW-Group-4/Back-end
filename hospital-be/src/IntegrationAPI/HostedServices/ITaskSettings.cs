using System;

namespace IntegrationAPI.HostedServices
{
    public class ITaskSettings <T>
    {
        string CronExpression { get; set; }
        TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
