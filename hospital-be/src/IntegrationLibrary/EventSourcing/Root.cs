using System;
using System.Collections.Generic;

namespace IntegrationLibrary.EventSourcing
{
    public abstract class Root
    {
        public Guid Id { get; protected set; }
        public List<DomainEvent> Events { get; protected set; }
        public int Version { get; protected set; }

        public Root(Guid id)
        {
            Id = id;
            Events = new List<DomainEvent>();
        }

        public abstract void Apply(DomainEvent @event);
    }
}