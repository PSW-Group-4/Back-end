using System;
using System.Collections.Generic;
using System.Linq;
using IntegrationLibrary.BloodSubscriptionResponses.Model;
using IntegrationLibrary.Exceptions;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace IntegrationLibrary.BloodSubscriptionResponses.Repository
{
    public class BloodSubscriptionResponseRepository : IBloodSubscriptionResponseRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodSubscriptionResponseRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public BloodSubscriptionResponse Create(BloodSubscriptionResponse subscription)
        {
            _context.BloodSubscriptionResponses.Add(subscription);
            _context.SaveChanges();
            return subscription;
        }

        public IEnumerable<BloodSubscriptionResponse> GetAll()
        {
            return _context.BloodSubscriptionResponses.ToList();
        }

        public BloodSubscriptionResponse GetById(Guid id)
        {
            BloodSubscriptionResponse subscription = _context.BloodSubscriptionResponses.Find(id);
            if (subscription == null)
                throw new NotFoundException();
            return subscription;
        }

        public BloodSubscriptionResponse GetBySubscriptionId(Guid id)
        {
            BloodSubscriptionResponse subscription = _context.BloodSubscriptionResponses
                .Where(sub => sub.Subscription.Id == id).FirstOrDefault();
            if (subscription == null)
                throw new NotFoundException();
            return subscription;
        }

        public BloodSubscriptionResponse Update(BloodSubscriptionResponse subscription)
        {
            BloodSubscriptionResponse local = _context.Set<BloodSubscriptionResponse>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(subscription.Id));
            // check if local is not null 
            if (local != null)
                // detach
                _context.Entry(local).State = EntityState.Detached;
            // set Modified flag in your entry
            _context.Entry(subscription).State = EntityState.Modified;

            // save 
            _context.SaveChanges();
            return subscription;
        }
    }
}