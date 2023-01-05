using System;
using System.Collections.Generic;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;

namespace HospitalLibrary.Infrastructure.EventSourcing
{
    public interface IEventRepository<TEvent, TAggregateRoot>
    {
        
        public void SaveEvent(TEvent @event);
        public  TAggregateRoot GetById(Guid id);
        public IEnumerable<TAggregateRoot> GetAll();
        public TEvent GetEventById(Guid id);
    }
}