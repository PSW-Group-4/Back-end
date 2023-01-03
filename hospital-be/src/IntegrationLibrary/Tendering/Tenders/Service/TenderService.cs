using System;
using System.Collections.Generic;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using IntegrationLibrary.EventSourcing;
using IntegrationLibrary.Tendering.DomainEvents.Base;
using IntegrationLibrary.Tendering.DomainEvents.Subtypes;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository;

namespace IntegrationLibrary.Tendering.Service
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _repository;
        private readonly IEventStore<TenderingEvent> _eventStore;

        public TenderService(ITenderRepository repository)
        {
            _repository = repository;
        }

        public TenderService(ITenderRepository repository, IEventStore<TenderingEvent> eventStore)
        {
            _repository = repository;
            _eventStore = eventStore;
        }

        public void Create(Tender tender)
        {
            _repository.Create(tender);
        }

        public void Create(IEnumerable<Blood> blood, DateTime deadline)
        {
            Tender.Create(blood, deadline);
        }

        public void Create(TenderCreatedEvent tenderCreatedEvent)
        {
            new Tender().Causes(tenderCreatedEvent);
            _eventStore.Save(tenderCreatedEvent);
        }

        public void Close(TenderFailedEvent tenderFailedEvent)
        {
            Tender tender = GetById(tenderFailedEvent.AggregateId);
            tender.Causes(tenderFailedEvent);
        }

        public void ConfirmWinner(WinnerChosenEvent winnerChosenEvent)
        {
            Tender tender = GetById(winnerChosenEvent.AggregateId);
            tender.Causes(winnerChosenEvent);
        }

        public IEnumerable<Tender> GetActive()
        {
            IEnumerable<Tender> all = _repository.GetAll();
            List<Tender> activeTenders = new List<Tender>();
            foreach (Tender tender in all){
                if (tender.IsActive()) {
                    activeTenders.Add(tender);
                }
            }
            IEnumerable<Tender> active = activeTenders;
            return active;
        }

        public IEnumerable<Tender> GetAll()
        {
            return _repository.GetAll();
        }
        public Tender GetById(Guid Id) 
        {
            return _repository.GetById(Id);
        }
    }
}
