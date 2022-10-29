using HospitalLibrary.Core.Repository;
using HospitalLibrary.Feedbacks.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Feedbacks.Repository
{
    public interface IFeedbackRepository : IRepositoryBase<Feedback>
    {
        Feedback Publish(Feedback feedback, JsonPatchDocument feedbackModel);
        Feedback Hide(Feedback feedback, JsonPatchDocument feedbackModel);
    }
}
