using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using IntegrationLibrary.Common;

namespace IntegrationLibrary.EventSourcing
{
    public abstract class AggregateRoot : Entity
    {
        public abstract void Apply(DomainEvent @event);
    }
}