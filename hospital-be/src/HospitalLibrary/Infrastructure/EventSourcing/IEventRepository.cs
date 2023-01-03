using System;

namespace HospitalLibrary.Infrastructure.EventSourcing
{
    public interface IEventRepository<TEvent, TAggregateRoot>
    {
        
        public void SaveEvent(TEvent @event);
        public  TAggregateRoot GetById(Guid id);
    }
}