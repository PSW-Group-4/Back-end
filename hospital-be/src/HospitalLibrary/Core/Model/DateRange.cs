using System;

namespace HospitalLibrary.Core.Model
{
    public class DateRange
    {
        public DateTime StartTime { get;  private set; }
        public DateTime EndTime { get;  private set ; }

        public DateRange() {}

        public DateRange(DateTime startTime, DateTime endTime) {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public Boolean OverlapsWith(DateRange dateRange) {
            // starts in interval
            // ends in interval
            // overshadows interval
            return  (this.StartTime <= dateRange.StartTime && this.EndTime > dateRange.StartTime) ||
                    (this.StartTime < dateRange.EndTime && this.EndTime >= dateRange.EndTime) ||
                    (this.StartTime >= dateRange.StartTime && this.EndTime < dateRange.EndTime);
        }

        // used for checking if appointment has ended
        public Boolean IsLesserThan(DateTime time) {
            return this.EndTime < time;
        }
    }
}