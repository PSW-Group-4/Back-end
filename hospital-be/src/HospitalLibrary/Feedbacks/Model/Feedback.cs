using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using Microsoft.AspNetCore.JsonPatch;
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
        public Status Status { get; private set; }
        public Guid PatientId { get; private set; }
        public virtual Patient Patient { get;  set; }
        public DateTime Date { get;  set; }

        public Feedback SetUp(Feedback feedback, Patient patient)
        {
            feedback.Date = DateTime.Now;
            feedback.Patient = patient;

            SetInitialStatus(feedback);

            return feedback;
        }

        private void SetInitialStatus(Feedback feedback)
        {
            if (feedback.IsDesiredPublic)
            {
                feedback.Status = Status.Pending;
            }
            else
            {
                feedback.Status = Status.Hidden;
            }
        }

        public void Update(Feedback feedback)
        {
            Text = feedback.Text;
            IsAnonimous = feedback.IsAnonimous;
            Status = feedback.Status;
            IsDesiredPublic = feedback.IsDesiredPublic ;
            Patient = feedback.Patient;
            Date = feedback.Date;
        }

        public Feedback Publish(Feedback feedback, JsonPatchDocument feedbackModel)
        {
            Status current = feedback.Status;
            feedbackModel.ApplyTo(feedback);

            if (IsAlreadyPublishedOrHidden(current, feedback))
            {
                throw new FeedbackAlreadyPublishedOrHidden();
            }

            return feedback;
        }

        private bool IsAlreadyPublishedOrHidden(Status current, Feedback feedback)
        {
            return current == feedback.Status;
        }
    }
}
