using IntegrationLibrary.BloodSubscriptionReponces.Model;
using IntegrationLibrary.BloodSubscriptionReponces.Repository;
using IntegrationLibrary.BloodSubscriptions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodSubscriptionReponces.Service
{
    public class BloodSubscriptionResponceService : IBloodSubscriptionResponceService
    {
        private readonly IBloodSubscriptionResponceRepository _repository;

        public BloodSubscriptionResponceService(IBloodSubscriptionResponceRepository repository)
        {
            _repository = repository;
        }
        public BloodSubscriptionRepsponce Create(BloodSubscriptionRepsponce subscription)
        {
            return _repository.Create(subscription);
        }

        public IEnumerable<BloodSubscriptionRepsponce> GetAll()
        {
            return _repository.GetAll();
        }

        public BloodSubscriptionRepsponce GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public BloodSubscriptionRepsponce GetBySubscriptionId(Guid id)
        {
            return _repository.GetBySubscriptionId(id);
        }

        public BloodSubscriptionRepsponce Update(BloodSubscriptionRepsponce subscription)
        {
            return _repository.Update(subscription);
        }
    }
}
