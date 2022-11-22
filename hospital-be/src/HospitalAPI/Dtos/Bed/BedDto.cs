using HospitalLibrary.RoomsAndEqipment.Model;
using System;

namespace HospitalAPI.Dtos.Bed
{
    public class BedDto
    {
        public Guid Id { get; set; }
        public Guid equipmentId { get; set; }
        public virtual Equipment equipment { get; set; }
        public bool IsFree { get; set; }
    }
}
