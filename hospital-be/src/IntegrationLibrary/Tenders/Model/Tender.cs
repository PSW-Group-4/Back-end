using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Tenders.Model
{
    [Table("tenders")]
    public class Tender
    {
        public Guid Id { get; set; }
        public BloodType BloodType { get; set; }
        public RHFactor RHFactor { get; set; }
        public double Amount { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime Deadline { get; set; }

        public Tender() { }
        public Tender(BloodType bloodType, RHFactor rHFactor, double amount, DateTime datePosted, DateTime deadline)
        {
            Id = Guid.NewGuid();   
            BloodType = bloodType;
            RHFactor = rHFactor;
            Amount = amount;
            DatePosted = datePosted;
            Deadline = deadline;
        }
    }
}
