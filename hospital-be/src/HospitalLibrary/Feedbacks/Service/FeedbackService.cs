using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Feedbacks.Repository;
using HospitalLibrary.Patients.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            feedback.Status = Status.Pending;
            feedback.Patient = _patientRepository.GetById(feedback.PatientId);
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

        public Feedback SetPublic(Feedback feedback)
        {
            feedback.SetPublic(feedback);
            return Update(feedback);
        }
        public Feedback SetPrivate(Feedback feedback)
        {
            feedback.SetPrivate(feedback);
            return Update(feedback);
        }

        public IEnumerable<Feedback> GetAllApproved()
        {
            List<Feedback> result = new List<Feedback>();
            foreach (Feedback feedback in _feedbackRepository.GetAll())
            {
                if (feedback.Status.Equals(Status.Approved)) result.Add(feedback);
            }
            return result;
        }
    }
}
