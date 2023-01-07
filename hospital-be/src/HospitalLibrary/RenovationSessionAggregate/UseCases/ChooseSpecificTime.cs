using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.RenovationSessionAggregate.UseCases
{
    public class ChooseSpecificTime
    {
        private IRenovationSessionAggregateRootRepository _sessionRepository;
        
        public ChooseSpecificTime(IRenovationSessionAggregateRootRepository sessionRepository) {
            this._sessionRepository = sessionRepository;
        }

        public void Execute(Guid id, DateRange dateRange) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ChooseSpecificTime(root.Id, dateRange);
        }
    }
}