using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestEditDto
    {
        public Guid requestId { get; set; }
        public String doctorId { get; set; }
        public BloodType bloodType { get; set; }
        public String reasonsWhyBloodIsNeeded { get; set; }
        public double bloodAmountInMilliliters { get; set; }
        public Boolean isApproved { get; set; }
        public String rejectionComment { get; set; }
        public String managerId { get; set; }
    }
}
