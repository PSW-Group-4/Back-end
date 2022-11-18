using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Feedbacks.Repository;
using HospitalLibrary.Patients.Repository;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Feedbacks.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IPatientRepository _patientRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository, IPatientRepository patientRepository)
        {
            _feedbackRepository = feedbackRepository;
            _patientRepository = patientRepository;
        }

        public Feedback Create(Feedback feedback)
        {
            feedback.Date = DateTime.Now;

            feedback.Patient = _patientRepository.GetById(feedback.PatientId);
            if (feedback.IsDesiredPublic)
            {
                feedback.Status = Status.Pending;
            }
            else
            {
                feedback.Status = Status.Hidden;
            }
            
            return _feedbackRepository.Create(feedback);
        }

        public void Delete(Guid feedbackId)
        {
            _feedbackRepository.Delete(feedbackId);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public Feedback GetById(Guid feedbackId)
        {
            return _feedbackRepository.GetById(feedbackId);
        }

        public Feedback Update(Feedback feedback)
        {
            return _feedbackRepository.Update(feedback);
        }

        public Feedback PublishHide(Feedback feedback, JsonPatchDocument feedbackModel)
        {
            return _feedbackRepository.PublishHide(feedback, feedbackModel);
        }

        public IEnumerable<Feedback> GetAllPublished()
        {
            return _feedbackRepository.GetAllPublished();
        }
    }
}
