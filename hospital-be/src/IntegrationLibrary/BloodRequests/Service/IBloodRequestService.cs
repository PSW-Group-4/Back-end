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
        public IEnumerable<BloodRequestDto> GetAll();
        public BloodRequestDto GetByBloodRequestId(Guid id);
        public BloodRequestDto Create(BloodRequestDto bloodRequest);
    }
}
