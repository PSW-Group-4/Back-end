using IntegrationLibrary.BloodRequests.Repository;
using IntegrationLibrary.BloodRequests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodRequests.Service
{
    public class BloodRequestService : IBloodRequestService
    {
        private readonly IBloodRequestRepository _repository;
        public BloodRequestService(IBloodRequestRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<BloodRequest> GetAll()
        {
            return _repository.GetAll();
        }

        public BloodRequest GetByBloodRequestId(Guid id)
        {
            throw new NotImplementedException();
        }
        public BloodRequest Create(BloodRequest bloodRequest)
        {
            return _repository.Create(bloodRequest);
        }
    }
}
