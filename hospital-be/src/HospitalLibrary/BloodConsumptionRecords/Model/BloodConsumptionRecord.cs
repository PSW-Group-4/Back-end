using System;
using HospitalLibrary.Doctors.Model;

namespace HospitalLibrary.BloodConsumptionRecords.Model
{
    public class BloodConsumptionRecord
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public double Amount { get; set; }
        public string BloodType { get; set; }
        public string Reason { get; set; }
        public DateTime DateTime { get; set; }

        public void Update(BloodConsumptionRecord bloodConsumptionRecord)
        {
            Amount = bloodConsumptionRecord.Amount;
            BloodType = bloodConsumptionRecord.BloodType;
            Reason = bloodConsumptionRecord.Reason;
        }
    }
}
