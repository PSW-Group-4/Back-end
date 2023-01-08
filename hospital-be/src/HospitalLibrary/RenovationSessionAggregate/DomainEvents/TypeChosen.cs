using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.EventSourcing;


namespace HospitalLibrary.RenovationSessionAggregate.DomainEvents
{
    public class TypeChosen : RenovationSessionEvent
    {
        public Renovation.Model.RenovationAppointment.TypeOfRenovation TypeOfRenovationChosen {get; private set;}

        public TypeChosen(Guid aggregateId) : base(aggregateId, DateTime.Now) {
        }

        public TypeChosen(Guid aggregateId, Renovation.Model.RenovationAppointment.TypeOfRenovation  type) : base(aggregateId, DateTime.Now) {
            this.TypeOfRenovationChosen = type;
        }
    }
}