using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodSubscriptions.Repository
{
    public interface IBloodSubscriptionRepository
    {
        public IEnumerable<BloodSubscription> GetAll();
        public BloodSubscription GetById(Guid id);
        public BloodSubscription Create(BloodSubscription subscription);
        public BloodSubscription Update(BloodSubscription subscription);
        public BloodSubscription GetByBbTitle(string title);
        public IEnumerable<BloodSubscription> GetNotUrgentLastMonth();
    }
}
