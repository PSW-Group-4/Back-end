using IntegrationLibrary.ManagerBloodRequests.Model;
using IntegrationLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.ManagerBloodRequests.Repository
{
    public class ManagerRequestRepository : IManagerRequestRepository
    {
        private readonly IntegrationDbContext _context;

        public ManagerRequestRepository(IntegrationDbContext context)
        {
            _context = context;
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
