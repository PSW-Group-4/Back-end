using System;

namespace IntegrationAPI.HostedServices
{
    public class TaskSettings<T> : ITaskSettings<T>
    {
        /*public string CronExpression { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }*/
        public TaskSettings(string v, TimeZoneInfo local)
        {
            CronExpression = v;
            TimeZoneInfo = local;
        }
    }
}
