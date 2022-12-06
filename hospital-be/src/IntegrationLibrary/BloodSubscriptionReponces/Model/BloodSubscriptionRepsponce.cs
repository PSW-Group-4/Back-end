using IntegrationLibrary.BloodSubscriptions;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodSubscriptionReponces.Model
{
    [Table("blood_subscription_responces")]
    public class BloodSubscriptionRepsponce : Entity
    {
        public virtual BloodSubscription Subscription {get; private set; }
        public string Message { get; private set; }

        public BloodSubscriptionRepsponce() { }
        public void SetMessage(String message) {

            Message = ValidateMessage(message) ? message : throw new ArgumentException();
        }
        public bool ValidateMessage(String message)
        {
            return message != null && message != "";
        }
        public void SetSubscription(BloodSubscription subscription)
        {
            Subscription = ValidateSubscription(subscription) ? subscription : throw new ArgumentException();
        }
        public bool ValidateSubscription(BloodSubscription subscription)
        {
            return subscription != null;
        }
    }
}
