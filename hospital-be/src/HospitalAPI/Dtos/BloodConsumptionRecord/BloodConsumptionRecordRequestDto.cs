using System;

namespace HospitalAPI.Dtos.BloodConsumptionRecord
{
    public class BloodConsumptionRecordRequestDto
    {
        public Guid DoctorId { get; set; }
        public double Amount { get; set; }
        public string BloodType { get; set; }
        public string Reason { get; set; }
        public DateTime DateTime { get; set; }
    }
}
