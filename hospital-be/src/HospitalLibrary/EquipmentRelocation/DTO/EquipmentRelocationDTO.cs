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
            this.DateRange = dateRange;
            this.Duration = duration;
            this.SourceId = sourceId;
            this.TargetId = targetId;
        }
    }
}
