using System;

namespace IntegrationLibrary.EventSourcing
{
    public interface IEventStore<TEvent>
    {
        public void Save(TEvent @event);
    }
}