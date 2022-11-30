using IntegrationLibrary.Tenders.Model;
using IntegrationLibrary.Tenders.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Tenders.Service
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _repository;

        public TenderService(ITenderRepository repository)
        {
            _repository = repository;
        }

        public void Create(Tender tender)
        {
            _repository.Create(tender);
        }

        public IEnumerable<Tender> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
