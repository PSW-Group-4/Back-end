using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EquipmentRelocation.DTO

{
    public class EquipmentRelocationDTO
    {
        public Guid Id { get; set; }
        public DateTime relocationStart { get; set; }
        public int duration { get; set; }
        public Guid sourceId { get; set; }
        public Guid targetId { get; set; }
        public EquipmentRelocationDTO() { }

        public EquipmentRelocationDTO(DateTime relocationStart, int duration, Guid sourceId, Guid targetId)
        {
            this.relocationStart = relocationStart;
            this.duration = duration;
            this.sourceId = sourceId;
            this.targetId = targetId;
        }
    }
}
