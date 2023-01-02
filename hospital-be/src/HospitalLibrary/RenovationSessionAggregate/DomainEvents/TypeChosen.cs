using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;


namespace HospitalLibrary.RenovationSessionAggregate.DomainEvents
{
    public class TypeChosen : DomainEvent
    {
        public Renovation.Model.RenovationAppointment.TypeOfRenovation Type {get; private set;}
        public TypeChosen(Guid aggregateId, Renovation.Model.RenovationAppointment.TypeOfRenovation  type) : base(aggregateId, DateTime.Now) {
            this.Type = type;
        }
    }
}