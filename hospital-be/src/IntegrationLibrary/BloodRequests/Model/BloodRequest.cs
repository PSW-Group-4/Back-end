using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodRequests.Model
{
    [Table("blood_requests")]
    public class BloodRequest
    {
        public Guid Id { get; set; }
        public String DoctorId { get; set; }
        public BloodType BloodType { get; set; }
        public RHFactor RHFactor { get; set; }
        public String ReasonsWhyBloodIsNeeded { get; set; }
        public double BloodAmountInMilliliters { get; set; }
        public Boolean IsApproved { get; set; }
        public String RejectionComment { get; set; }
        public String ManagerId { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime SendOnDate { get; set; }
        public bool IsUrgent { get; set; }
    }
}
