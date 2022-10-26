using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.Utilities;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Service
{
    public class BloodBankService : IBloodBankService
    {
        private readonly IBloodBankRepository _repository;

        public BloodBankService(IBloodBankRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<BloodBank> GetAll()
        {
            return _repository.GetAll();
        }

        public BloodBank GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public BloodBank Create(BloodBank bloodBank)
        {
            
            bloodBank.ApiKey = ApiKeyGeneration.generateKey();
            bloodBank.Password = PasswordHandler.GeneratePassword();
            //EmailSending.sendEmail(CreateEmailMessage(bloodBank));
            return _repository.Create(bloodBank);
        }
        private MimeMessage CreateEmailMessage(BloodBank bloodBank)
        {
            String emailBody = "API key:" + bloodBank.ApiKey + NewLineFormat.Unix +
                                "Password:" + bloodBank.Password + NewLineFormat.Unix +
                                "Link: links go here"; //TODO: Add link to public front app to settings and pass it here

           return EmailSending.createTxtEmail(bloodBank.Name, bloodBank.EmailAddress, "PSW Integrations", emailBody);
        }
    }
}
