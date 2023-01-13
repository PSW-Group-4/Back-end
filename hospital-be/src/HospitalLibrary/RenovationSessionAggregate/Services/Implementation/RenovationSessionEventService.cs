using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Services.Interfaces;
using HospitalLibrary.RenovationSessionAggregate.DomainEvents;
using HospitalLibrary.RenovationSessionAggregate.Repository.Interfaces;

namespace HospitalLibrary.RenovationSessionAggregate.Services.Implementation
{
    public class RenovationSessionEventService : IRenovationSessionEventService
    {
        private readonly IRenovationSessionEventRepository _renovationSessionEventRepository;

        public RenovationSessionEventService(IRenovationSessionEventRepository repository)
        {
            _renovationSessionEventRepository = repository;
        }

        public RenovationSessionEvent Create(RenovationSessionEvent entity)
        {
            return _renovationSessionEventRepository.Create(entity);
        }

        public void Delete(Guid id)
        {   
            _renovationSessionEventRepository.Delete(id);
        }

        public IEnumerable<RenovationSessionEvent> GetAll()
        {
            return _renovationSessionEventRepository.GetAll();
        }

        public RenovationSessionEvent GetById(Guid id)
        {
            return _renovationSessionEventRepository.GetById(id);
        }

        public RenovationSessionEvent Update(RenovationSessionEvent entity)
        {
            return _renovationSessionEventRepository.Update(entity);
        }

        public IEnumerable<RenovationSessionEvent> GetAllForRootId(Guid id) {
            List<RenovationSessionEvent> events = new List<RenovationSessionEvent>();
            foreach(RenovationSessionEvent e in this.GetAll()) {
                if(e.AggregateId.Equals(id)) {
                    events.Add(e);
                }
            }
            return events;
        }
    }
}