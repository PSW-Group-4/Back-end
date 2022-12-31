using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.Renovation.EventSourcing.DomainEvents;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Renovation.EventSourcing
{
    public class RenovationSessionAggregateRoot : EventSourcingRoot
    {
        public RenovationAppointment.TypeOfRenovation TypeOfRenovation {get; private set;}
        private IEnumerable<RoomRenovationPlan> _RoomRenovationPlans {get; set;}
        public IEnumerable<RoomRenovationPlan> RoomRenovationPlans {
            get { return new List<RoomRenovationPlan>(_RoomRenovationPlans); }
            private set {_RoomRenovationPlans = value;}
        }

        public DateRange DateRange { get; private set; }

        public RenovationSessionAggregateRoot(Guid id) : base(id) {
            this.RoomRenovationPlans = new List<RoomRenovationPlan>();
        }


        public Guid SessionStarted() {
            Id = Guid.NewGuid();
            Causes(new SessionStarted(Id));
            return Id;
        }

        public RenovationSessionAggregateRoot SessionEnded(Guid id) {
            Causes(new SessionEnded(id));
            return this;
        }

        public void TypeChosen(Guid id, Renovation.Model.RenovationAppointment.TypeOfRenovation type) {
            Causes(new TypeChosen(id, type));
        }

        public void Causes(DomainEvent @event) {
            Events.Add(@event);
            Apply(@event);
        }

        protected override void Apply(DomainEvent @event) {
            When((dynamic)@event);
            Version = Version++;
        }

        public void When(SessionEnded @event) {
            // Apply all events and create and save appointment
            
        }

    }
}