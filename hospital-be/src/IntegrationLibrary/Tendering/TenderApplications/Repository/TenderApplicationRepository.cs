using IntegrationLibrary.Exceptions;
using IntegrationLibrary.Settings;
using IntegrationLibrary.TenderApplications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.TenderApplications.Repository
{
    public class TenderApplicationRepository : ITenderApplicationRepository
    {
        private readonly IntegrationDbContext _context;

        public TenderApplicationRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public TenderApplication Submit(TenderApplication tenderApplication)
        {
            _context.TenderApplications.Add(tenderApplication);
            _context.SaveChanges();
            return tenderApplication;
        }

        public TenderApplication FindById(Guid applicationId)
        {
            TenderApplication tenderApplication = _context.TenderApplications.Find(applicationId);
            if (tenderApplication == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return tenderApplication;
            }
        }

        public IEnumerable<TenderApplication> GetAll()
        {
            
            return _context.TenderApplications.ToList();
        }
    }
}
