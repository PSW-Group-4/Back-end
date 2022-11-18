using IntegrationLibrary.BloodRequests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodRequests.Service
{
    public interface IBloodRequestService
    {
        public IEnumerable<BloodRequest> GetAll();
        public BloodRequest GetByBloodRequestId(Guid id);
        public BloodRequest Create(BloodRequest bloodRequest);
    }
}
