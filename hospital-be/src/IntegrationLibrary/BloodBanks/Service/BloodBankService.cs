using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
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
            return _repository.Create(bloodBank);
        }
    }
}
