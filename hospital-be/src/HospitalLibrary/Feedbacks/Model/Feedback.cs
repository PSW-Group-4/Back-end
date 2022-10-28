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
        Published,
        Hidden,
        Pending
    }
    public class Feedback
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsAnonimous { get; set; }
        public bool IsDesiredPublic { get;  set; }
        public Status Status { get; set; }
        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public DateTime Date { get; set; }

        public void Update(Feedback feedback)
        {
            Text = feedback.Text;
            IsAnonimous = feedback.IsAnonimous;
            Status = feedback.Status;
            IsDesiredPublic = feedback.IsDesiredPublic ;
            Patient = feedback.Patient;
            Date = feedback.Date;
        }

        public Feedback Publish(Feedback feedback)
        {
            feedback.Status = Status.Published;
            return feedback;
        }
        public Feedback Hide(Feedback feedback)
        {
            feedback.Status = Status.Hidden;
            return feedback;
        }
    }
}
