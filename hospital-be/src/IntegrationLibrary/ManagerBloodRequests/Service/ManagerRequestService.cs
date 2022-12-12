using IntegrationLibrary.ManagerBloodRequests.Model;
using IntegrationLibrary.ManagerBloodRequests.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.ManagerBloodRequests.Service
{
    public class ManagerRequestService : IManagerRequestService
    {
        private readonly IManagerRequestRepository _repository;

        public ManagerRequestService(IManagerRequestRepository repository)
        {
           _repository = repository;
        }
        public ManagerRequest Create(ManagerRequest bloodRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ManagerRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public ManagerRequest GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ManagerRequest Update(ManagerRequest bloodRequest)
        {
            throw new NotImplementedException();
        }
    }
}
