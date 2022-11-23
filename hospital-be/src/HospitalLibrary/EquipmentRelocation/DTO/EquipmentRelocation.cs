using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EquipmentRelocation.DTO

{
    public class EquipmentRelocation
    {
        public DateTime relocationStart { get; set; }
        public int duration { get; set; }
        public Guid sourceId { get; set; }
        public Guid targetId { get; set; }
        public EquipmentRelocation() { }

        public EquipmentRelocation(DateTime relocationStart, int duration, Guid sourceId, Guid targetId)
        {
            this.relocationStart = relocationStart;
            this.duration = duration;
            this.sourceId = sourceId;
            this.targetId = targetId;
        }
    }
}
