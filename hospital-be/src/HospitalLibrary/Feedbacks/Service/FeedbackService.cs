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

            //  feedback.Patient = _patientRepository.GetById(feedback.PatientId);
            feedback.Patient = _patientRepository.GetAll().FirstOrDefault();
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

        public Feedback Publish(Feedback feedback)
        {
            feedback.Publish(feedback);
            return Update(feedback);
        }
        public Feedback Hide(Feedback feedback)
        {
            feedback.Hide(feedback);
            return Update(feedback);
        }

        public IEnumerable<Feedback> GetAllPublished()
        {
            List<Feedback> result = new List<Feedback>();
            foreach (Feedback feedback in _feedbackRepository.GetAll())
            {
                if (feedback.Status.Equals(Status.Published)) result.Add(feedback);
            }
            return result;
        }
    }
}
