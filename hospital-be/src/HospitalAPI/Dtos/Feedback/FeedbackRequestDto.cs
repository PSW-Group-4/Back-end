using System;

namespace HospitalAPI.Dtos.Feedback
{
    public class FeedbackRequestDto
    {
        public string Text { get; set; }
        public bool IsAnonimous { get; set; }
        public bool IsDesiredPublic { get; set; }
        public Guid PatientId { get; set; }
    }
}