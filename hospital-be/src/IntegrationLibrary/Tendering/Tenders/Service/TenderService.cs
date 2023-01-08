using System;
using System.Collections.Generic;
using IntegrationLibrary.EventSourcing;
using IntegrationLibrary.Tendering.DomainEvents.Base;
using IntegrationLibrary.Tendering.DomainEvents.Subtypes;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository;

namespace IntegrationLibrary.Tendering.Service
{
    public class TenderService : ITenderService
    {
        private readonly IEventStore<TenderingEvent> _eventStore;
        private readonly ITenderRepository _repository;

       
        public TenderService(ITenderRepository repository, IEventStore<TenderingEvent> eventStore)
        {
            _repository = repository;
            _eventStore = eventStore;
        }

        public void Create(Tender tender)
        {
            _repository.Create(tender);
        }

        public void Create(TenderCreatedEvent tenderCreatedEvent)
        {
            Tender tender = new();
            tender.Causes(tenderCreatedEvent);
            _eventStore.Save(tenderCreatedEvent);
            _repository.Create(tender);
            
        }

        public IEnumerable<Tender> GetActive()
        {
            IEnumerable<Tender> all = _repository.GetAll();
            List<Tender> activeTenders = new();
            foreach (Tender tender in all)
                if (tender.IsActive())
                    activeTenders.Add(tender);
            IEnumerable<Tender> active = activeTenders;
            return active;
        }

        public IEnumerable<Tender> GetAll()
        {
            return _repository.GetAll();
        }

        public Tender GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Fail(TenderFailedEvent tenderFailedEvent)
        {
            Tender tender = GetById(tenderFailedEvent.AggregateId);
            tender.InitializeEvents();
            tender.Causes(tenderFailedEvent);
            _eventStore.Save(tenderFailedEvent);
        }

        public void ChooseWinner(WinnerChosenEvent winnerChosenEvent)
        {
            Tender tender = GetById(winnerChosenEvent.AggregateId);
            tender.InitializeEvents();
            tender.Causes(winnerChosenEvent);
            _eventStore.Save(winnerChosenEvent);
        }

        public void ConfirmWinner(WinnerConfirmedEvent winnerConfirmedEvent)
        {
            Tender tender = GetById(winnerConfirmedEvent.AggregateId);
            tender.InitializeEvents();
            tender.Causes(winnerConfirmedEvent);
            _eventStore.Save(winnerConfirmedEvent);
        }
    }
}