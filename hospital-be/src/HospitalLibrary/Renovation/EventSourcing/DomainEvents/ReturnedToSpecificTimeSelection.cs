using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.EventSourcingCore;

namespace HospitalLibrary.Renovation.EventSourcing.DomainEvents
{
    public class ReturnedToSpecificTimeSelection : DomainEvent
    {
        public ReturnedToSpecificTimeSelection(Guid aggregateId) : base(aggregateId){
            
        }
    }
}