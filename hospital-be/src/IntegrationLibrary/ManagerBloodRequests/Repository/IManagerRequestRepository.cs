using IntegrationLibrary.ManagerBloodRequests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.ManagerBloodRequests.Repository
{
    public interface IManagerRequestRepository
    {
        public IEnumerable<ManagerRequest> GetAll();
        public ManagerRequest GetById(Guid id);
        public ManagerRequest Create(ManagerRequest bloodRequest);
        public ManagerRequest Update(ManagerRequest bloodRequest);
    }
}
