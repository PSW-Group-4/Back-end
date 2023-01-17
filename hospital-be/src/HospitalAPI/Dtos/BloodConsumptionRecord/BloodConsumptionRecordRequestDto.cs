using HospitalLibrary.BloodConsumptionRecords.Model;
using System;

namespace HospitalAPI.Dtos.BloodConsumptionRecord
{
    public class BloodConsumptionRecordRequestDto
    {
        public Guid DoctorId { get; set; }
        public Amount Amount { get; set; }
        public string BloodType { get; set; }
        public string Reason { get; set; }
        public DateTime DateTime { get; set; }
    }
}
