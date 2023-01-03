using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using IntegrationLibrary.Common;

namespace IntegrationLibrary.EventSourcing
{
    public abstract class AggregateRoot : Entity
    {
        [JsonIgnore]
        public List<DomainEvent> Events { get; protected set; }

        public abstract void Apply(DomainEvent @event);
    }
}