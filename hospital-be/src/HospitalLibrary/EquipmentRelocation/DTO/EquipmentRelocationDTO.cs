using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI.Dtos.Patient;
namespace HospitalLibrary.EquipmentRelocation.DTO

{
    public class EquipmentRelocationDTO
    {

        public DateRange DateRange { get; set; }
        public int Duration { get; set; }
        public Guid SourceId { get; set; }
        public Guid TargetId { get; set; }
        public EquipmentRelocationDTO() { }

        public EquipmentRelocationDTO(DateRange dateRange, int duration, Guid sourceId, Guid targetId)
        {
            this.DateRange = this.CheckDateRange(dateRange);
            this.Duration = this.CheckDuration(duration);
            this.SourceId = sourceId;
            this.TargetId = targetId;
        }

        //Minutes should be 0, 15, 30, 45
        private DateRange CheckDateRange(DateRange dateRange)
        {
            DateTime start = dateRange.StartTime;
            DateTime end = dateRange.EndTime;
            if (start.Minute % 15 != 0)
            {
                start = start.AddMinutes(15 - start.Minute % 15);
            }
            if (end.Minute % 15 != 0)
            {
                end = end.AddMinutes(15 - end.Minute % 15);
            }
            return new DateRange(start, end);
        }
        private int CheckDuration(int duration)
        {
            if (duration % 15 != 0)
            {
                duration += 15 - duration % 15;
            }
            return duration;
        }
    }
}
