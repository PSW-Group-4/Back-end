using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.EventSourcingCore;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.Renovation.EventSourcing.DomainEvents
{
    public class OldRoomsChosen : DomainEvent
    {
        private IEnumerable<RoomRenovationPlan> _RoomRenovationPlans {get; set;}
        public IEnumerable<RoomRenovationPlan> RoomRenovationPlans {
            get { return new List<RoomRenovationPlan>(_RoomRenovationPlans); }
            private set {_RoomRenovationPlans = value;}
        }

        public OldRoomsChosen(Guid aggregateId, IEnumerable<RoomRenovationPlan> renovationPlans) : base(aggregateId) {
            this.RoomRenovationPlans = renovationPlans;
        }
    }
}