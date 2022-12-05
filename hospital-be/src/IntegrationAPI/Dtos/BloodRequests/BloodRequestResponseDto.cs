using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestResponseDto
    {
        public Guid RequestId { get; set; }
        public String Status { get; set; }
    }
}
