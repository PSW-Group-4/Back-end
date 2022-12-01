using System;

namespace HospitalLibrary.Core.Model
{
    public class DateRange
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public DateRange() {}

        public DateRange(DateTime startTime, DateTime endTime) {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}