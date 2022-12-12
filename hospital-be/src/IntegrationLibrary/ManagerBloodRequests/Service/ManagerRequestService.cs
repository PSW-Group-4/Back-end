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
            return _repository.Create(bloodRequest);
        }

        public IEnumerable<ManagerRequest> GetAll()
        {
            return _repository.GetAll();
        }

        public ManagerRequest GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public ManagerRequest Update(ManagerRequest bloodRequest)
        {
            return _repository.Update(bloodRequest);    
        }
    }
}
