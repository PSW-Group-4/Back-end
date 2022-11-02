using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Repository
{
    public interface IBloodBankRepository
    {
        public IEnumerable<BloodBank> GetAll();
        public BloodBank GetById(Guid id);
        public BloodBank Create(BloodBank bank);
        public IEnumerable<String> GetApiKeys();
        public BloodBank GetByApiKey(String ApiKey);
        public BloodBank Update(BloodBank bloodBank);



    }
}
