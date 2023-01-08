using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.RenovationSessionAggregate.DomainEvents
{
    public class TimeframeCreated : RenovationSessionEvent
    {
        public DateTime Start {get; private set;}
        public DateTime End {get; private set;}

        public TimeframeCreated(Guid aggregateId) : base(aggregateId, DateTime.Now){
        }
        
        public TimeframeCreated(Guid aggregateId, DateTime start, DateTime end) : base(aggregateId, DateTime.Now){
            this.Start = start;
            this.End = end;
        }
    }
}