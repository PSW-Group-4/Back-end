using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.RenovationSessionAggregate.DomainEvents
{
    public class OldRoomsChosen : RenovationSessionEvent
    {
        private IEnumerable<RoomRenovationPlan> _RoomRenovationPlans {get; set;}
        public IEnumerable<RoomRenovationPlan> RoomRenovationPlans {
            get { return new List<RoomRenovationPlan>(_RoomRenovationPlans); }
            private set {_RoomRenovationPlans = value;}
        }

        public OldRoomsChosen(Guid aggregateId) : base(aggregateId, DateTime.Now) {
        }

        public OldRoomsChosen(Guid aggregateId, IEnumerable<RoomRenovationPlan> roomRenovationPlans) : base(aggregateId, DateTime.Now) {
            this.RoomRenovationPlans = roomRenovationPlans;
        }
    }
}