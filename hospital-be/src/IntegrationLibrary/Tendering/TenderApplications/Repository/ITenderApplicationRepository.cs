using IntegrationLibrary.TenderApplications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.TenderApplications.Repository
{
   public interface ITenderApplicationRepository
    {
        public IEnumerable<TenderApplication> GetAll();
        public TenderApplication FindById(Guid applicationId);
        public TenderApplication Submit(TenderApplication tenderApplication);
    }
}
