using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.EventSourcingCore;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Renovation.EventSourcing.DomainEvents
{
    public class SpecificTimeChosen : DomainEvent
    {
        public DateRange DateRange {get; private set;}
        public SpecificTimeChosen(Guid aggregateId, DateRange dateRange) : base(aggregateId){
            this.DateRange = dateRange;
        }
    }
}