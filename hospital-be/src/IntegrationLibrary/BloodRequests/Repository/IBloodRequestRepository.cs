using IntegrationLibrary.BloodRequests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodRequests.Repository
{
   public interface IBloodRequestRepository
    {
        public IEnumerable<BloodRequest> GetAll();
        public BloodRequest GetById(Guid id);
        public BloodRequest Create(BloodRequest bloodRequest);
        public BloodRequest Update(BloodRequest bloodRequest);
        public IEnumerable<BloodRequest> GetUnapproved();
        public IEnumerable<BloodRequest> GetAllUrgentApprovedNotSent();
    }
}
