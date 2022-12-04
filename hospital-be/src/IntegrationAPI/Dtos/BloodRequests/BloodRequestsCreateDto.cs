using IntegrationAPI.Dtos.BloodProducts;
using IntegrationLibrary.Common;
using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestsCreateDto
    {
        public String DoctorId { get; set; }
        public BloodDto BloodDto { get; set; }
        public String Reasons { get; set; }
        public DateTime SendOnDate { get; set; }
        public bool IsUrgent { get; set; }
    }
}
