using IntegrationAPI.Dtos.BloodProducts;
using IntegrationLibrary.Common;
using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestsCreateDto
    {
        public String DoctorId { get; set; }
        public BloodProductDto BloodProduct { get; set; }
        public String ReasonsWhyBloodIsNeeded { get; set; }
        public DateTime SendOnDate { get; set; }
    }
}
