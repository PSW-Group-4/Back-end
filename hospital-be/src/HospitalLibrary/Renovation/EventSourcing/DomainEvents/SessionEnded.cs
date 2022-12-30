using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.EventSourcingCore;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.Renovation.EventSourcing.DomainEvents
{
    public class SessionEnded : DomainEvent
    {
        public RenovationAppointment Appointment {get; private set;}
        public SessionEnded(Guid aggregateId) : base(aggregateId){
            
        }
    }
}