using IntegrationLibrary.Exceptions;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodSubscriptions.Repository
{
    public class BloodSubscriptionRepository : IBloodSubscriptionRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodSubscriptionRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public BloodSubscription Create(BloodSubscription subscription)
        {
            _context.BloodSubscription.Add(subscription);
            _context.SaveChanges();
            return subscription;
        }

        public IEnumerable<BloodSubscription> GetAll()
        {
            return _context.BloodSubscription.ToList();
        }

        public BloodSubscription GetByBbTitle(string title)
        {
            BloodSubscription subscription = _context.BloodSubscription.Where(sub => sub.BloodBankName == title).First();
            if (subscription == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return subscription;
            }
        }

        public BloodSubscription GetById(Guid id)
        {
            BloodSubscription subscription = _context.BloodSubscription.Find(id);
            if (subscription == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return subscription;
            }
        }

        public BloodSubscription Update(BloodSubscription subscription)
        {
            var local = _context.Set<BloodSubscription>()
                 .Local
                 .FirstOrDefault(entry => entry.Id.Equals(subscription.Id));
            // check if local is not null 
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _context.Entry(subscription).State = EntityState.Modified;

            // save 
            _context.SaveChanges();
            return subscription;
        }
    }
}
