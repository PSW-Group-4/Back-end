using System;

namespace IntegrationAPI.Dtos.BloodBankNews
{
    public class NewsDto
    {
        public Guid id { get; set; }
        public string bloodBank { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public long milliseconds { get; set; }
    }
}
