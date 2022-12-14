using System;
using System.Collections.Generic;
using IntegrationLibrary.BloodSubscriptions.Repository;

namespace IntegrationLibrary.BloodSubscriptions.Service
{
    public class BloodSubscriptionService : IBloodSubscriptionService
    {
        private readonly IBloodSubscriptionRepository _repository;

        public BloodSubscriptionService(IBloodSubscriptionRepository repository)
        {
            _repository = repository;
        }

        public BloodSubscription Create(BloodSubscription subscription)
        {
            return _repository.Create(subscription);
        }

        public IEnumerable<BloodSubscription> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<BloodSubscription> GetActiveNotSent()
        {
            return _repository.GetActiveNotSent();
        }

        public BloodSubscription GetByBbTitle(string title)
        {
            return _repository.GetByBbTitle(title);
        }

        public BloodSubscription GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public BloodSubscription Update(BloodSubscription subscription)
        {
            return _repository.Update(subscription);
        }
    }
}