using IntegrationLibrary.BloodSubscriptionReponces.Model;
using IntegrationLibrary.Exceptions;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodSubscriptionReponces.Repository
{
    public class BloodSubscriptionResponceRepository : IBloodSubscriptionResponceRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodSubscriptionResponceRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public BloodSubscriptionRepsponce Create(BloodSubscriptionRepsponce subscription)
        {
            _context.BloodSubscriptionRepsponce.Add(subscription);
            _context.SaveChanges();
            return subscription;
        }

        public IEnumerable<BloodSubscriptionRepsponce> GetAll()
        {
            return _context.BloodSubscriptionRepsponce.ToList();
        }

        public BloodSubscriptionRepsponce GetById(Guid id)
        {
            var subscription = _context.BloodSubscriptionRepsponce.Find(id);
            if (subscription == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return subscription;
            }
        }

        public BloodSubscriptionRepsponce GetBySubscriptionId(Guid id)
        {
            var subscription = _context.BloodSubscriptionRepsponce.Where(sub=> sub.Subscription.Id == id).FirstOrDefault(); 
            if (subscription == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return subscription;
            }
        }

        public BloodSubscriptionRepsponce Update(BloodSubscriptionRepsponce subscription)
        {
            var local = _context.Set<BloodSubscriptionRepsponce>()
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
