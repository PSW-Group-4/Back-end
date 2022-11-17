using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.Settings;
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
        public IEnumerable<BloodRequestDto> GetAll()
        {
            return _context.BloodRequests.ToList();
        }

        public BloodRequestDto GetByBloodRequestId()
        {
            throw new NotImplementedException();
        }

        public BloodRequestDto Create(BloodRequestDto bloodRequest)
        {
            _context.BloodRequests.Add(bloodRequest);
            _context.SaveChanges();
            return bloodRequest;
        }
    }
}
