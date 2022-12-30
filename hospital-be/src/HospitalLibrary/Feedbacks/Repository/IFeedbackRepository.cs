using HospitalLibrary.Core.Repository;
using HospitalLibrary.Feedbacks.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Feedbacks.Repository
{
    public interface IFeedbackRepository : IRepositoryBase<Feedback>
    {
        //Feedback PublishHide(Feedback feedback, JsonPatchDocument feedbackModel);
        IEnumerable<Feedback> GetAllPublished();
    }
}
