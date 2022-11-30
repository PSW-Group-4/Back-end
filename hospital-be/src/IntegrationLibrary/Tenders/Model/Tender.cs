using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using IntegrationLibrary.Exceptions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegrationLibrary.Tenders.Model
{
    [Table("tenders")]
    public class Tender : Entity
    {
        public BloodType BloodType { get; private set; }
        public double Amount { get; private set; }
        public DateTime Deadline { get; private set; }

        public Tender() { }

        private Tender(BloodType bloodType, double amount, DateTime deadline)
        {
            Id = Guid.NewGuid();
            BloodType = bloodType;
            Amount = amount;
            CreatedDate = DateTime.Now;
            Deadline = deadline;
            Version = 1.0;
        }

        public bool IsActive()
        {
            return DateTime.Compare(DateTime.Now, Deadline) < 0;
        }

        public static Tender Create(BloodType bloodType, double amount, DateTime deadline)
        {
            if(DateTime.Compare(DateTime.Now, deadline) < 0)
            {
                return new Tender(bloodType, amount, deadline);
            } else
            {
                throw new DateIsBeforeTodayException();
            }
        }
    }
}
