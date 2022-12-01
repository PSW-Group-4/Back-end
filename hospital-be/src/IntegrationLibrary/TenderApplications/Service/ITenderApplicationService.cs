using IntegrationLibrary.TenderApplications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntegrationLibrary.TenderApplications.Service
{
   public interface ITenderApplicationService
    {
         IEnumerable<TenderApplication> GetAll();
        TenderApplication FindById(Guid applicationId);
        TenderApplication Apply(TenderApplication application);
    }
}
