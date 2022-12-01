using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodSubscriptions.Service
{
    public class BloodSubscriptionService : IBloodSubscriptionService
    {
        private readonly IBloodSubscriptionService _repository;
        public BloodSubscriptionService(IBloodSubscriptionService repository)
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
