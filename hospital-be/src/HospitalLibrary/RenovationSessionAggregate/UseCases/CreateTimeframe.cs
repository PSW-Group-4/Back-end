using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.RenovationSessionAggregate.UseCases
{
    public class CreateTimeframe
    {
        private IRenovationSessionAggregateRootRepository _sessionRepository;
        
        public CreateTimeframe(IRenovationSessionAggregateRootRepository sessionRepository) {
            this._sessionRepository = sessionRepository;
        }

        public void Execute(Guid id, DateRange dateRange) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.CreateTimeframe(root.Id, dateRange);
        }
    }
}