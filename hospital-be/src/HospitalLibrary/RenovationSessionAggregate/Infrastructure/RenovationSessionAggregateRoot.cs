using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.RenovationSessionAggregate.DomainEvents;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.RenovationSessionAggregate.Infrastructure
{
    public class RenovationSessionAggregateRoot : EventSourcingRoot
    {
        public RenovationAppointment.TypeOfRenovation? TypeOfRenovation {get; private set;}
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

        public void SessionEnded(Guid id) {
            Causes(new SessionEnded(id));
        }

        public void TypeChosen(Guid id, Renovation.Model.RenovationAppointment.TypeOfRenovation type) {
            Causes(new TypeChosen(id, type));
        }

        public void OldRoomsChosen(Guid id, IEnumerable<RoomRenovationPlan> plans) {
            Causes(new OldRoomsChosen(id, plans));
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
            return;
        }
        public void When(SessionStarted @event) {
            return;
        }

        public void When(TypeChosen @event) {
            this.TypeOfRenovation = @event.Type;
            this.RoomRenovationPlans = new List<RoomRenovationPlan>();
        }
        
        public void When(OldRoomsChosen @event) {
            this.RoomRenovationPlans.ToList().AddRange(@event.RoomRenovationPlans);
        }

        public void When(NewRoomsCreated @event) {
            this.RoomRenovationPlans.ToList().AddRange(@event.RoomRenovationPlans);
        }

        public void When(TimeframeCreated @event) {
            this.DateRange = @event.DateRange;
        }

        public void When(SpecificTimeChosen @event) {
            this.DateRange = @event.DateRange;
        }

        // sets daterange to last known value
        public void When(ReturnedToSpecificTimeSelection @event) {
            DomainEvent lastEvent = this.Events.ToList().FindAll(de => de.GetType() == typeof(TimeframeCreated) || de.GetType() == typeof(SpecificTimeChosen)).SkipLast(1).TakeLast(1).First();
            if(lastEvent != null) {
                this.DateRange = ((dynamic)lastEvent).DateRange;
            }
            else{
                this.DateRange = null;
            }
        }

        public void When(ReturnedToTimeframeCreation @event) {
            DomainEvent lastEvent = this.Events.ToList().FindAll(de => de.GetType() == typeof(TimeframeCreated)).SkipLast(1).TakeLast(1).First();
            if(lastEvent != null) {
                this.DateRange = ((dynamic)lastEvent).DateRange;
            }
            else{
                this.DateRange = null;
            }
        }

        public void When(ReturnedToNewRoomCreation @event) {
            DomainEvent lastEvent = this.Events.ToList().FindAll(de => de.GetType() == typeof(OldRoomsChosen)).SkipLast(1).TakeLast(1).First();
            if(lastEvent != null) {
                this.RoomRenovationPlans = ((dynamic)lastEvent).RoomRenovationPlans;
            }
            else{
                this.RoomRenovationPlans = new List<RoomRenovationPlan>();
            }
        }

        public void When(ReturnedToOldRoomsSelection @event) {
            this.RoomRenovationPlans = new List<RoomRenovationPlan>();
            this.DateRange = null;
        }

        public void When(ReturnedToTypeSelection @event) {
            DomainEvent lastEvent = this.Events.ToList().FindAll(de => de.GetType() == typeof(TypeChosen)).SkipLast(1).TakeLast(1).First();
            if(lastEvent != null) {
                this.TypeOfRenovation = ((dynamic)lastEvent).Type;
            }
            else{
                this.TypeOfRenovation = null;
            }
            this.RoomRenovationPlans = new List<RoomRenovationPlan>();
            this.DateRange = null;
        }
        
        public void Update(RenovationSessionAggregateRoot entity) {
            this.DateRange = entity.DateRange;
            this.RoomRenovationPlans = entity.RoomRenovationPlans;
        }
        

        

    }
}