using HospitalLibrary.Core.Service;
using HospitalLibrary.Feedbacks.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Feedbacks.Service
{
    public interface IFeedbackService : IServiceBase<Feedback> 
    {
        public Feedback Publish(Feedback feedback, JsonPatchDocument feedbackModel);
        public Feedback Hide(Feedback feedback, JsonPatchDocument feedbackModel);
        public IEnumerable<Feedback> GetAllPublished();
    }
}
