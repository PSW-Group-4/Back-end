using System;

namespace IntegrationLibrary.EventSourcing
{
    public interface IEventRepository<TEvent, TAggregateRoot>
    {
        public void SaveEvent(TEvent @event);
        public  TAggregateRoot GetById(Guid id);
    }
}