using System;

namespace IntegrationAPI.HostedServices
{
    public class TaskSettings<T> : ITaskSettings<T>
    {
        public string cronExpression { get; set; }
        public TimeZoneInfo timeZoneInfo { get; set; }
        public TaskSettings(string v, TimeZoneInfo local)
        {
            cronExpression = v;
            timeZoneInfo = local;
        }
    }
}
