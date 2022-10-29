using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Feedbacks.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly HospitalDbContext _context;

        public FeedbackRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Feedback Create(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
            return feedback;
        }

        public void Delete(Guid feedbackId)
        {
            var feedback = GetById(feedbackId);
            _context.Feedbacks.Remove(feedback);
            _context.SaveChanges();
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _context.Feedbacks.ToList();
        }

        public IEnumerable<Feedback> GetAllPublished()
        {
            //return _context.Feedbacks.FromSql("Select * from Feedbacks").ToList();
            return _context.Feedbacks.FromSqlRaw("select * from \"Feedbacks\" where \"Status\" = 0").ToList();
        }

        public Feedback GetById(Guid feedbackId)
        {
            var result = _context.Feedbacks.Find(feedbackId);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Feedback PublishHide(Feedback feedback, JsonPatchDocument feedbackModel)
        {
            feedbackModel.ApplyTo(feedback);
            _context.SaveChanges();
            return feedback;
        }

        public Feedback Update(Feedback feedback)
        {
            var updatingFeedback = _context.Feedbacks.SingleOrDefault(p => p.Id == feedback.Id);
            if (updatingFeedback == null)
            {
                throw new NotFoundException();
            }
            updatingFeedback.Update(feedback);
            _context.SaveChanges();
            return updatingFeedback;
        }
    }
}
