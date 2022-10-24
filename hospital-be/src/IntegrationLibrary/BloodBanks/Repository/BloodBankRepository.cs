using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Exceptions;
using IntegrationLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Repository
{
    public class BloodBankRepository : IBloodBankRepository
    {
        private readonly IntegrationDbContext _context;
        
        public BloodBankRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public BloodBank Create(BloodBank bank)
        {
            _context.BloodBanks.Add(bank);
            _context.SaveChanges();
            return bank;
        }

        public IEnumerable<BloodBank> GetAll()
        {
            return _context.BloodBanks.ToList();
        }

        public BloodBank GetById(Guid id)
        {
            BloodBank bloodBank = _context.BloodBanks.Find(id);
            if(bloodBank == null)
            {
                throw new NotFoundException();
            } else
            {
                return bloodBank;
            }
        }
    }
}
