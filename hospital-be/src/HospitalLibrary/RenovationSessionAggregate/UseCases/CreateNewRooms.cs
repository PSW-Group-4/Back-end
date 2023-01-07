using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.RenovationSessionAggregate.UseCases
{
    public class CreateNewRooms
    {
        private IRenovationSessionAggregateRootRepository _sessionRepository;
        
        public CreateNewRooms(IRenovationSessionAggregateRootRepository sessionRepository) {
            this._sessionRepository = sessionRepository;
        }

        public void Execute(Guid id, IEnumerable<RoomRenovationPlan> rooms) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            root.CreateNewRooms(root.Id, rooms);
        }
    }
}