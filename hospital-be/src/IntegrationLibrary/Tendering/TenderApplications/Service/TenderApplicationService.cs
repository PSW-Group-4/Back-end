using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.TenderApplications.Model;
using IntegrationLibrary.TenderApplications.Repository;
using IntegrationLibrary.Utilities;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.EventSourcing;
using IntegrationLibrary.Tendering.DomainEvents.Base;
using IntegrationLibrary.Tendering.DomainEvents.Subtypes;
using IntegrationLibrary.Tendering.Repository;

namespace IntegrationLibrary.TenderApplications.Service
{
    public class TenderApplicationService : ITenderApplicationService
    {
        private readonly ITenderApplicationRepository _repository;
        private readonly IEventStore<TenderingEvent> _eventStore;
        public TenderApplicationService(ITenderApplicationRepository repository, IEventStore<TenderingEvent> eventStore)
        {
            _repository = repository;
            _eventStore = eventStore;
        }

        public TenderApplication Submit(TenderApplication application)
        {
            return _repository.Submit(application);
        }
        public void Submit(AppliedToTenderEvent appliedToTenderEvent)
        {
            TenderApplication tenderApplication = new();
            tenderApplication.Causes(appliedToTenderEvent);
            _eventStore.Save(appliedToTenderEvent);
            _repository.Submit(tenderApplication);
        }
        public string GenerateWinnerMessage(TenderApplication application) {
            return "Dear sir/madam we are happy to inform you that we have accepted your offer for our tender, please follow the link" +
                " to accept the terms of the tender. Kind regards Zdravo hospital." +
                "http://localhost:4200/bloodBank/tender/winner/" + application.Tender.Id;
        }
        public string GenerateRejectionMessage() {
            return "Dear sir/madam we are sorry to inform you that we have chosen a different offer, thank you for applying for our tender," +
                " we hope to work with you again, Kind regards Zdravo hospital";
        }
        public bool SendEmailsToParticipants(TenderApplication application, string winnerMessage, string rejectionMessage) {
            foreach (TenderApplication tenderApplication in GetByTender(application.Tender.Id))
            {
                if (tenderApplication.BloodBank.EmailAddress.Equals(application.BloodBank.EmailAddress))
                {
                    MimeMessage email = EmailSending.CreateTxtEmail(tenderApplication.BloodBank.Name, tenderApplication.BloodBank.EmailAddress, "Tender results", winnerMessage);
                    EmailSending.SendEmail(email);
                }
                else
                {
                    MimeMessage email = EmailSending.CreateTxtEmail(tenderApplication.BloodBank.Name, tenderApplication.BloodBank.EmailAddress, "Tender results", rejectionMessage);
                    EmailSending.SendEmail(email);
                }
            }
            return true;
        }
        public bool NotifyParticipants(TenderApplication application)
        {
            string winnerMessage = GenerateWinnerMessage(application);
            string rejectionMessage = GenerateRejectionMessage();
            return SendEmailsToParticipants(application, winnerMessage, rejectionMessage);
        }

        public TenderApplication FindById(Guid applicationId)
        {
            return _repository.FindById(applicationId);
        }

        public IEnumerable<TenderApplication> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TenderApplication> GetByTender(Guid tenderId)
        {
            IEnumerable<TenderApplication> all = GetAll();
            List<TenderApplication> applicationsByTender = new();
            foreach(TenderApplication application in all) {
                if (application.Tender.Id.Equals(tenderId)) {
                    applicationsByTender.Add(application);
                }
            }
            IEnumerable<TenderApplication> tenderApplications = applicationsByTender;
            return tenderApplications;
        }
    }
}
