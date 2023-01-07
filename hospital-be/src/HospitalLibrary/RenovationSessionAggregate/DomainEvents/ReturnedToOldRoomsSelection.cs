using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;


namespace HospitalLibrary.RenovationSessionAggregate.DomainEvents
{
    public class ReturnedToOldRoomsSelection : RenovationSessionEvent
    {
        public ReturnedToOldRoomsSelection(Guid aggregateId) : base(aggregateId, DateTime.Now){
            
        }
    }
}