using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Exceptions;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
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

        public BloodBank GetByName(string name)
        {
            return _context.BloodBanks.Where(bloodBank => bloodBank.Name == name).FirstOrDefault();
        }

        public IEnumerable<string> GetApiKeys()
        {
            return _context.BloodBanks.Select(bank => bank.ApiKey);
        }
        public BloodBank GetByApiKey(string ApiKey)
        {
            BloodBank bloodBank = _context.BloodBanks.SingleOrDefault(e => e.ApiKey == ApiKey);
            if (bloodBank == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return bloodBank;
            }
        }
        public BloodBank Update(BloodBank bloodBank) {
            var local = _context.Set<BloodBank>()
     .Local
     .FirstOrDefault(entry => entry.Id.Equals(bloodBank.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _context.Entry(bloodBank).State = EntityState.Modified;

            // save 
            _context.SaveChanges();
            return bloodBank;
        }

        public BloodBank GetByEmail(string email)
        {
            BloodBank bloodBank = _context.BloodBanks.SingleOrDefault(e => e.EmailAddress == email);
            if (bloodBank == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return bloodBank;
            }
        }
    }
}
