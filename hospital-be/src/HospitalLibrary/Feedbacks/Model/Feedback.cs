using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Feedbacks.Model
{
    public enum Status
    {
        Approved,
        Denied,
        Pending
    }
    public class Feedback
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsAnonimous { get; set; }
        public bool IsPublic { get; private set; }
        public Status Status { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }

        public void Update(Feedback feedback)
        {
            Text = feedback.Text;
            IsAnonimous = feedback.IsAnonimous;
            Status = feedback.Status;
            IsPublic = feedback.IsPublic;
            Patient = feedback.Patient;
            Date = feedback.Date;
        }

        public Feedback SetPublic(Feedback feedback)
        {
            IsPublic = true;
            return feedback;
        }
        public Feedback SetPrivate(Feedback feedback)
        {
            IsPublic = false;
            return feedback;
        }
    }
}
