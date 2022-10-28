using HospitalAPI.Controllers.Dtos.Patient;
using HospitalLibrary.Feedbacks.Model;
using System;

namespace HospitalAPI.Controllers.Dtos.Feedback
{
    public class FeedbackRequestDto
    {
        public string Text { get; set; }
        public bool IsAnonimous { get; set; }
        public bool IsPublic { get;  set; }
        public Guid PatientId { get; set; }
    }
}