using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.RenovationSessionAggregate.UseCases
{
    public class ChooseType
    {
        private IRenovationSessionAggregateRootRepository _sessionRepository;
        
        public ChooseType(IRenovationSessionAggregateRootRepository sessionRepository) {
            this._sessionRepository = sessionRepository;
        }

        public void Execute(Guid id, RenovationAppointment.TypeOfRenovation type) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ChooseType(root.Id, type);
        }
    }
}