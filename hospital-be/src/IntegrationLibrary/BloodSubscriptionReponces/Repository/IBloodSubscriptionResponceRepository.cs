using IntegrationLibrary.BloodSubscriptionReponces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodSubscriptionReponces.Repository
{
    public interface IBloodSubscriptionResponceRepository
    {
        public IEnumerable<BloodSubscriptionRepsponce> GetAll();
        public BloodSubscriptionRepsponce GetById(Guid id);
        public BloodSubscriptionRepsponce Create(BloodSubscriptionRepsponce subscription);
        public BloodSubscriptionRepsponce Update(BloodSubscriptionRepsponce subscription);
        public BloodSubscriptionRepsponce GetBySubscriptionId(Guid id);
    }
}
