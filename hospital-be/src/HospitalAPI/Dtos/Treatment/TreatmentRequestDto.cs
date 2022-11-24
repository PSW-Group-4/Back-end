using System;

namespace HospitalAPI.Dtos.Treatment
{
    public class TreatmentRequestDto
    {
        public Guid MedicineId { get; set; }    
        public Guid BloodConsumptionRecordId { get; set; }
        public DateTime DateChanged { get; set; }
    }
}
