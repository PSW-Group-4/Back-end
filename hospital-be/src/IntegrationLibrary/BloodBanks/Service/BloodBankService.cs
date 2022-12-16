using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.Utilities;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Exceptions;

namespace IntegrationLibrary.BloodBanks.Service
{
    public class BloodBankService : IBloodBankService
    {
        private readonly IBloodBankRepository _repository;
        private readonly IPasswordHandler _passwordHandler;

        public BloodBankService(IBloodBankRepository repository, IPasswordHandler passwordHandler)
        {
            _repository = repository;
            _passwordHandler = passwordHandler;
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
            string generatedPassword = _passwordHandler.Generate();
            bloodBank.Password = generatedPassword;
            return _repository.Create(bloodBank);
        }
        public BloodBank GetByApiKey(string ApiKey) {
            return _repository.GetByApiKey(ApiKey);
        }
        public BloodBank Update(BloodBank bloodBank) {
            bloodBank.Password = _passwordHandler.Hash(bloodBank, bloodBank.Password);
            bloodBank.Activated = true;
            return _repository.Update(bloodBank);
        }
        public BloodBank GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public BloodBank GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public string Authenticate(string email, string password)
        {
            BloodBank bloodBank = _repository.GetByEmail(email);
            if(bloodBank == null)
            {
                throw new NotFoundException();
            } else if (!bloodBank.Activated)
            {
                throw new AccountNotActivated();
            }
            PasswordVerificationResult verificationResult = _passwordHandler.Verify(bloodBank, password);
            if(verificationResult == PasswordVerificationResult.Failed)
            {
                throw new BadCredentialsException();
            } else {
                return JwtService.GenerateToken(bloodBank);
            }

        }
    }
}
