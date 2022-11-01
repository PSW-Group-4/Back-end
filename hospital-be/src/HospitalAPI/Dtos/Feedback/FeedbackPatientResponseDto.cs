using System;

namespace HospitalAPI.Dtos.Feedback
{
    public class FeedbackPatientResponseDto
    {
        public string PatientFullname { get; set; }
        public DateTime Date  { get; set; }
        public string Text { get; set; }
    }
}