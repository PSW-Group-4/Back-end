using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Renovation.EventSourcing.DomainEvents
{
    public class TimeframeCreated : DomainEvent
    {
        public DateRange DateRange {get; private set;}
        public TimeframeCreated(Guid aggregateId, DateRange dateRange) : base(aggregateId, DateTime.Now){
            this.DateRange = dateRange;
        }
    }
}