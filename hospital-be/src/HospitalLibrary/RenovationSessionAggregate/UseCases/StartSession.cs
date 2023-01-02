using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;

namespace HospitalLibrary.RenovationSessionAggregate.UseCases
{
    public class StartSession
    {
        private IRenovationSessionAggregateRootRepository _sessionRepository;
        // TODO
        // private IEventRepository _eventRepository
        
        public StartSession(IRenovationSessionAggregateRootRepository sessionRepository) {
            this._sessionRepository = sessionRepository;
        }

        public Guid Execute() {
            RenovationSessionAggregateRoot root = new RenovationSessionAggregateRoot(Guid.NewGuid());
            root.SessionStarted();
            this._sessionRepository.Create(root);
            // save event changes
            return root.Id;
        }
    }
}