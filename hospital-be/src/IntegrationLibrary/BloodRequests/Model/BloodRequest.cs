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
    public class BloodRequestDto
    {
        [Key]
        public Guid requestId { get; set; }
        public String doctorId { get; set; }
        public BloodType bloodType { get; set; }
        public String reasonsWhyBloodIsNeeded { get; set; }
        public double bloodAmountInMilliliters { get; set; }
        public Boolean isApproved { get; set; }
        public String rejectionComment { get; set; }
        public String managerId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
