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

        public IEnumerable<Tender> GetActive()
        {
            IEnumerable<Tender> all = _repository.GetAll();
            List<Tender> activeTenders = new List<Tender>();
            foreach (Tender tender in all){
                if (tender.IsActive()) {
                    activeTenders.Add(tender);
                }
            }
            IEnumerable<Tender> active = activeTenders;
            return active;
        }

        public IEnumerable<Tender> GetAll()
        {
            return _repository.GetAll();
        }
        public Tender GetById(Guid Id) 
        {
            return _repository.GetById(Id);
        }
    }
}
