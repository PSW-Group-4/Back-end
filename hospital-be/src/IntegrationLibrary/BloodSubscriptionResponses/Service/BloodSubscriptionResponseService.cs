using System;
using System.Collections.Generic;
using IntegrationLibrary.BloodSubscriptionResponses.Model;
using IntegrationLibrary.BloodSubscriptionResponses.Repository;

namespace IntegrationLibrary.BloodSubscriptionResponses.Service
{
    public class BloodSubscriptionResponseService : IBloodSubscriptionResponseService
    {
        private readonly IBloodSubscriptionResponseRepository _repository;

        public BloodSubscriptionResponseService(IBloodSubscriptionResponseRepository repository)
        {
            _repository = repository;
        }

        public BloodSubscriptionResponse Create(BloodSubscriptionResponse subscription)
        {
            return _repository.Create(subscription);
        }

        public IEnumerable<BloodSubscriptionResponse> GetAll()
        {
            return _repository.GetAll();
        }

        public BloodSubscriptionResponse GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public BloodSubscriptionResponse GetBySubscriptionId(Guid id)
        {
            return _repository.GetBySubscriptionId(id);
        }

        public BloodSubscriptionResponse Update(BloodSubscriptionResponse subscription)
        {
            return _repository.Update(subscription);
        }
    }
}