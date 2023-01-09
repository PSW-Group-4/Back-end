using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;

namespace HospitalLibrary.RenovationSessionAggregate.DomainEvents
{
    public class RenovationSessionEvent : DomainEvent
    {
        public RenovationSessionEvent(Guid aggregateId, DateTime occurrenceTime) : base(aggregateId, occurrenceTime){
            
        }
    }
}