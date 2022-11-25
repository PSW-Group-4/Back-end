using System;

namespace HospitalAPI.Dtos.Treatment
{
    public class TreatmentRequestDto
    {
        public Nullable<Guid> MedicineId { get; set; }    
        public Nullable<Guid> BloodConsumptionRecordId { get; set; }
        public DateTime DateChanged { get; set; }
    }
}
