using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class ManagerBloodRequestDto
    {
        public string bloodBank { get; set; }
        public string bloodType { get; set; }
        public double amount { get; set; }
        public Guid id { get; set; }
        public string sendOnDate { get; set; }
        public bool urgent { get; set; }
    }
}
