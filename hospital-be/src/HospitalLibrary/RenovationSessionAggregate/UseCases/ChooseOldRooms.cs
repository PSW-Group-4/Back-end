using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.RenovationSessionAggregate.UseCases
{
    public class ChooseOldRooms
    {
        private IRenovationSessionAggregateRootRepository _sessionRepository;
        
        public ChooseOldRooms(IRenovationSessionAggregateRootRepository sessionRepository) {
            this._sessionRepository = sessionRepository;
        }

        public void Execute(Guid id, IEnumerable<RoomRenovationPlan> rooms) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.ChooseOldRooms(root.Id, rooms);
        } 
    }
}