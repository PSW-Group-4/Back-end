using System;

namespace HospitalAPI.HostedService
{
    public class ITaskSettings<T>
    {
        public string CronExpression { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
