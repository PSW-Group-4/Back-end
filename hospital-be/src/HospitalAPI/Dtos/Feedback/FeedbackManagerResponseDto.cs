using System;

namespace HospitalAPI.Dtos.Feedback
{
    public enum Status
    {
        Approved,
        Denied,
        Pending
    }
    public class FeedbackManagerResponseDto
    {
        public  Guid Id { get; set; }
        public string PatientFullname { get; set; }
        public DateTime Date  { get; set; }
        public string Text { get; set; }
        public Status Status { get; set; } 
        public bool IsDesiredPublic { get; set; } 
    }
}