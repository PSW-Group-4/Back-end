using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.EventSourcingCore;


namespace HospitalLibrary.Renovation.EventSourcing.DomainEvents
{
    public class TypeChosen : DomainEvent
    {
        public Renovation.Model.RenovationAppointment.TypeOfRenovation Type {get; private set;}
        public TypeChosen(Guid aggregateId, Renovation.Model.RenovationAppointment.TypeOfRenovation  type) : base(aggregateId) {
            this.Type = type;
        }
    }
}