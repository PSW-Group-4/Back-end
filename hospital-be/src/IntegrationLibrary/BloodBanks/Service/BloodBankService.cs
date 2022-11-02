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
            string generatedPassword = PasswordHandler.GeneratePassword();
            //when we figure out how to do dependency injection in .Net, call:
            //string hashedPassword = passwordHandler.HashPassword(generatedPassword);
            //and set that as blood bank's password
            bloodBank.Password = generatedPassword;
            //Keep the .sendEmail commented no need to spam people or me
            //EmailSending.sendEmail(EmailSending.createTxtEmail(bloodBank.Name, bloodBank.EmailAddress, Settings.EmailingResources.EmailSubjectBB, EmailSending.CreateEmailText(bloodBank)));
           
            return _repository.Create(bloodBank);
        }
        public BloodBank GetByApiKey(String ApiKey) {
            return _repository.GetByApiKey(ApiKey);
        }
        public BloodBank Update(BloodBank bloodBank) {
            BloodBank toUpdate = _repository.GetById(bloodBank.Id);
            toUpdate.Name = bloodBank.Name;
            toUpdate.Password = bloodBank.Password;
            toUpdate.ServerAddress = bloodBank.ServerAddress;
            return _repository.Update(bloodBank);
        }
        
    }
}
