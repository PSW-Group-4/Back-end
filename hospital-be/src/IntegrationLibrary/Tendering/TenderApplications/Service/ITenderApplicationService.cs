using IntegrationLibrary.TenderApplications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Tendering.DomainEvents.Subtypes;


namespace IntegrationLibrary.TenderApplications.Service
{
   public interface ITenderApplicationService
    {
         IEnumerable<TenderApplication> GetAll();
        IEnumerable<TenderApplication> GetByTender(Guid tenderId);
        TenderApplication FindById(Guid applicationId);
        TenderApplication Submit(TenderApplication application);
        void Submit(AppliedToTenderEvent appliedToTenderEvent);
        Boolean NotifyParticipants(TenderApplication application);
        public bool SendEmailsToParticipants(TenderApplication application, string winnerMessage, string rejectionMessage);
        public string GenerateRejectionMessage();
        public string GenerateWinnerMessage(TenderApplication application);
    }
}
