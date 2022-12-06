using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodRequests.Repository
{
    public class BloodRequestRepository : IBloodRequestRepository
    {
        private readonly IntegrationDbContext _context;
        public BloodRequestRepository(IntegrationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<BloodRequest> GetAll()
        {
            return _context.BloodRequests.ToList();
        }

        public BloodRequest GetById(Guid id)
        {
            return _context.BloodRequests.Find(id);
        }

        public IEnumerable<BloodRequest> GetUnapproved()
        {
            return _context.BloodRequests.Where(b => b.IsApproved == false);
        }

        public BloodRequest Create(BloodRequest bloodRequest)
        {
            _context.BloodRequests.Add(bloodRequest);
            _context.SaveChanges();
            return bloodRequest;
        }

        public BloodRequest Update(BloodRequest bloodRequest)
        {
            var local = _context.Set<BloodRequest>().Local.FirstOrDefault(entry => entry.Id.Equals(bloodRequest.Id));
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Update(bloodRequest);
            _context.Entry(bloodRequest).State = EntityState.Modified;
            _context.SaveChanges();
            return bloodRequest;
        }
    }
}
