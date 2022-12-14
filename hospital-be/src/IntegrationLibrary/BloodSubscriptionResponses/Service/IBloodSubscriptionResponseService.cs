using System;
using System.Collections.Generic;
using IntegrationLibrary.BloodSubscriptionResponses.Model;

namespace IntegrationLibrary.BloodSubscriptionResponses.Service
{
    public interface IBloodSubscriptionResponseService
    {
        public IEnumerable<BloodSubscriptionResponse> GetAll();
        public BloodSubscriptionResponse GetById(Guid id);
        public BloodSubscriptionResponse Create(BloodSubscriptionResponse subscription);
        public BloodSubscriptionResponse Update(BloodSubscriptionResponse subscription);
        public BloodSubscriptionResponse GetBySubscriptionId(Guid id);
    }
}