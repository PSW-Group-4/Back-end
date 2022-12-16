using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

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
        public virtual Patient Patient { get; private set; }
        public DateTime Date { get; private  set; }

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
            Status newStatus = (Status)Int32.Parse(feedbackModel.Operations[0].value.ToString());
            Status current = feedback.Status;

            if (IsAlreadyPublishedOrHidden(current, newStatus))
            {
                throw new FeedbackAlreadyPublishedOrHidden();
            }

            feedback.Status = newStatus;

            return feedback;
        }

        private bool IsAlreadyPublishedOrHidden(Status current, Status newStatus)
        {
            return current == newStatus;
        }

        public override bool Equals(object obj)
        {
            return obj is Feedback feedback &&
                   Id.Equals(feedback.Id) &&
                   Text == feedback.Text &&
                   IsAnonimous == feedback.IsAnonimous &&
                   IsDesiredPublic == feedback.IsDesiredPublic &&
                   Status == feedback.Status &&
                   PatientId.Equals(feedback.PatientId) &&
                   EqualityComparer<Patient>.Default.Equals(Patient, feedback.Patient) &&
                   Date == feedback.Date;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Text, IsAnonimous, IsDesiredPublic, Status, PatientId, Patient, Date);
        }
    }
}
