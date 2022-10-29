using HospitalLibrary.Patients.Model;
using System;

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
        public Guid Id { get; private set; }
        public string Text { get; private set; }
        public bool IsAnonimous { get; private set; }
        public bool IsDesiredPublic { get;  private set; }
        public Status Status { get;  set; }
        public Guid PatientId { get; private set; }
        public virtual Patient Patient { get;  set; }
        public DateTime Date { get;  set; }

        public void Update(Feedback feedback)
        {
            Text = feedback.Text;
            IsAnonimous = feedback.IsAnonimous;
            Status = feedback.Status;
            IsDesiredPublic = feedback.IsDesiredPublic ;
            Patient = feedback.Patient;
            Date = feedback.Date;
        }
    }
}
