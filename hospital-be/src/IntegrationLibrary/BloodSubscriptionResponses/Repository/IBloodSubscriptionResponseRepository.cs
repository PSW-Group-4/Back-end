using System;
using System.Collections.Generic;
using IntegrationLibrary.BloodSubscriptionResponses.Model;

namespace IntegrationLibrary.BloodSubscriptionResponses.Repository
{
    public interface IBloodSubscriptionResponseRepository
    {
        public IEnumerable<BloodSubscriptionResponse> GetAll();
        public BloodSubscriptionResponse GetById(Guid id);
        public BloodSubscriptionResponse Create(BloodSubscriptionResponse subscription);
        public BloodSubscriptionResponse Update(BloodSubscriptionResponse subscription);
        public BloodSubscriptionResponse GetBySubscriptionId(Guid id);
    }
}