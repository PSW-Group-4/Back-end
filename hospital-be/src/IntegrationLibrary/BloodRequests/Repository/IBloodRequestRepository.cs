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
        public IEnumerable<BloodRequestDto> GetAll();
        public BloodRequestDto GetByBloodRequestId();
        public BloodRequestDto Create(BloodRequestDto bloodRequest);
    }
}
