using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;

namespace HospitalLibrary.RenovationSessionAggregate.UseCases
{
    public class ReturnToSpecificTimeSelection
    {
        private IRenovationSessionAggregateRootRepository _sessionRepository;
        
        public ReturnToSpecificTimeSelection(IRenovationSessionAggregateRootRepository sessionRepository) {
            this._sessionRepository = sessionRepository;
        }

        public void Execute(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToSpecificTimeSelection(root.Id);
        }
    }
}