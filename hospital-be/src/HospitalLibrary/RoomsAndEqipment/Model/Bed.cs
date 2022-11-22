using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class Bed 
    { 
        public Guid Id { get; set; }

        public Guid equipmentId { get; set; }
        public virtual Equipment equipment { get; set; }
        public bool IsFree { get; set; }

        public void Update(Bed bed)
        {
            equipmentId = bed.equipmentId;
            IsFree = bed.IsFree;
        }

        public void FreeBed(Bed bed)
        {
            IsFree = true;
        }
        public void CaptureBed(Bed bed)
        {
            IsFree = false;
        }
    }
}
