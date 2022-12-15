using System;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.BloodConsumptionRecords.Model
{
    public class BloodConsumptionRecord
    {
        public Guid Id { get; private set; }
        public Guid DoctorId { get; private set; }
        public virtual Doctor Doctor { get; private set; }
        public Amount Amount { get; private set; }
        public string BloodType { get; private set; }
        public string Reason { get; private set; }
        public DateTime DateTime { get; private set; }

        public BloodConsumptionRecord()
        {
            DateTime = DateTime.Now;
        }

        public BloodConsumptionRecord(Guid id, Guid doctorId, Amount amount, string bloodType, string reason, DateTime dateTime)
        {
            Id = id;
            DoctorId = doctorId;
            Amount = amount;
            BloodType = bloodType;
            Reason = reason;
            DateTime = DateTime.Now;
            if (!Validate()) throw new EntityObjectValidationFailedException();
        }

        public void Update(BloodConsumptionRecord bloodConsumptionRecord)
        {
            Amount = bloodConsumptionRecord.Amount;
            BloodType = bloodConsumptionRecord.BloodType;
            Reason = bloodConsumptionRecord.Reason;
            if (!Validate()) throw new EntityObjectValidationFailedException();
        }

        public void SetDate()
        {
            DateTime = DateTime.Now;
        }

        private bool Validate()
        {
            if (String.IsNullOrWhiteSpace(BloodType) || String.IsNullOrWhiteSpace(Reason) || Amount == null)
                return false;
            return true;
        }
    }
}
