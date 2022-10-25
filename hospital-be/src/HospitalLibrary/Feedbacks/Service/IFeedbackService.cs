using HospitalLibrary.Core.Service;
using HospitalLibrary.Feedbacks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Feedbacks.Service
{
    public interface IFeedbackService : IServiceBase<Feedback> 
    {
        public Feedback SetPublic(Feedback feedback);
        public Feedback SetPrivate(Feedback feedback);
        public IEnumerable<Feedback> GetAllApproved();
    }
}
