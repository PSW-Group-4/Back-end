using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;

namespace HospitalLibrary.RenovationSessionAggregate.UseCases
{
    public class ReturnToTypeSelection
    {
        private IRenovationSessionAggregateRootRepository _sessionRepository;
        
        public ReturnToTypeSelection(IRenovationSessionAggregateRootRepository sessionRepository) {
            this._sessionRepository = sessionRepository;
        }

        public void Execute(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ReturnToTypeSelection(root.Id);
        }
    }
}