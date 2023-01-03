using IntegrationLibrary.TenderApplications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntegrationLibrary.TenderApplications.Service
{
   public interface ITenderApplicationService
    {
         IEnumerable<TenderApplication> GetAll();
        IEnumerable<TenderApplication> GetByTender(Guid tenderId);
        TenderApplication FindById(Guid applicationId);
        TenderApplication Apply(TenderApplication application);
        Boolean AcceptOffer(TenderApplication application);
        public bool SendEmailsToParticipants(TenderApplication application, string winnerMessage, string rejectionMessage);
        public string GenerateRejectionMessage();
        public string GenerateWinnerMessage(TenderApplication application);
    }
}
