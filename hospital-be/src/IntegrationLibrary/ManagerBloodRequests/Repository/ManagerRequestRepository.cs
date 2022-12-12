using IntegrationLibrary.Exceptions;
using IntegrationLibrary.ManagerBloodRequests.Model;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
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
            _context.ManagerBloodRequests.Add(bloodRequest);
            _context.SaveChanges();
            return bloodRequest;
        }

        public IEnumerable<ManagerRequest> GetAll()
        {
            return _context.ManagerBloodRequests.ToList();
        }

        public ManagerRequest GetById(Guid id)
        {
            var request = _context.ManagerBloodRequests.Find(id);
            if (request == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return request;
            }
        }

        public ManagerRequest Update(ManagerRequest bloodRequest)
        {
            var local = _context.Set<ManagerRequest>()
                 .Local
                 .FirstOrDefault(entry => entry.Id.Equals(bloodRequest.Id));
            // check if local is not null 
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _context.Entry(bloodRequest).State = EntityState.Modified;

            // save 
            _context.SaveChanges();
            return bloodRequest;
        }
    }
}
