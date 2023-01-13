using System;
using System.Collections.Generic;
using IntegrationLibrary.Tendering.DomainEvents.Subtypes;
using IntegrationLibrary.Tendering.Model;

namespace IntegrationLibrary.Tendering.Service
{
    public interface ITenderService
    {
        void Create(Tender tender);
        void Create(TenderCreatedEvent tenderCreatedEvent);
        IEnumerable<Tender> GetAll();
        Tender GetById(Guid Id);
        IEnumerable<Tender> GetActive();
        void ConfirmWinner(WinnerConfirmedEvent winnerConfirmedEvent);
        void ChooseWinner(WinnerChosenEvent winnerChosenEvent);
    }
}
