using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.RenovationSessionAggregate.DomainEvents
{
    public class SpecificTimeChosen : RenovationSessionEvent
    {
        public DateRange DateRange {get; private set;}
        public SpecificTimeChosen(Guid aggregateId, DateRange dateRange) : base(aggregateId, DateTime.Now){
            this.DateRange = dateRange;
        }
    }
}