using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;

namespace HospitalLibrary.RenovationSessionAggregate.DomainEvents
{
    public class ReturnedToSpecificTimeSelection : RenovationSessionEvent
    {
        public ReturnedToSpecificTimeSelection(Guid aggregateId) : base(aggregateId, DateTime.Now){
            
        }
    }
}