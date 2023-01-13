using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace HospitalLibrary.Infrastructure.EventSourcing
{
    public abstract class EventSourcingRoot
    {
        public Guid Id { get; protected set; }
        public virtual List<DomainEvent> Events { get; protected set; }
        public int Version { get; protected set; }

        public EventSourcingRoot(Guid id)
        {
            Id = id;
            Events = new List<DomainEvent>();
        }

        public abstract void Apply(DomainEvent @event);
        //Causes and When methods must be declared and implemented in inheriting class because of polymorphism restrictions in C#
    }
}
