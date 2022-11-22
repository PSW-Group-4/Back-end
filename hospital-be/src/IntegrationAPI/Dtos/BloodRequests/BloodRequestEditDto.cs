using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestEditDto
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
    }
}
