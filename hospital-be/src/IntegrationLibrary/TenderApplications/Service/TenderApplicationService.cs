using IntegrationLibrary.TenderApplications.Model;
using IntegrationLibrary.TenderApplications.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.TenderApplications.Service
{
    public class TenderApplicationService : ITenderApplicationService
    {
        private readonly ITenderApplicationRepository _repository;
        public TenderApplicationService(ITenderApplicationRepository repository)
        {
            _repository = repository;
        }

        public TenderApplication Apply(TenderApplication tenderApplication)
        {
            throw new NotImplementedException();
        }

        public TenderApplication FindById(Guid applicationId)
        {
            return _repository.FindById(applicationId);
        }

        public IEnumerable<TenderApplication> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
