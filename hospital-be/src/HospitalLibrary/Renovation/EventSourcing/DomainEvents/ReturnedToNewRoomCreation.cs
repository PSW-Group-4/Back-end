using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.EventSourcingCore;

namespace HospitalLibrary.Renovation.EventSourcing.DomainEvents
{
    public class ReturnedToNewRoomCreation : DomainEvent
    {
        public ReturnedToNewRoomCreation(Guid aggregateId) : base(aggregateId){
            
        }
    }
}