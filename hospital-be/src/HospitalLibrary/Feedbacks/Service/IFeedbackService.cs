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
        public Feedback PublishHide(Feedback feedback, JsonPatchDocument feedbackModel);
        public IEnumerable<Feedback> GetAllPublished();
    }
}
