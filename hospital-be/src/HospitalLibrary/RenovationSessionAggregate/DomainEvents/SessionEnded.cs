using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.RenovationSessionAggregate.DomainEvents
{
    public class SessionEnded : RenovationSessionEvent
    {
        public SessionEnded(Guid aggregateId) : base(aggregateId, DateTime.Now){
            
        }
    }
}