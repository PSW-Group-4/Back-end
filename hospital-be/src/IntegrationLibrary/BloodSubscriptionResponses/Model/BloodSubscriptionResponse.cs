using System;
using System.ComponentModel.DataAnnotations.Schema;
using IntegrationLibrary.BloodSubscriptions;
using IntegrationLibrary.Common;

namespace IntegrationLibrary.BloodSubscriptionResponses.Model
{
    [Table("blood_subscription_responces")]
    public class BloodSubscriptionResponse : Entity
    {
        public virtual BloodSubscription Subscription { get; private set; }
        public string Message { get; private set; }

        public void SetMessage(string message)
        {
            Message = ValidateMessage(message) ? message : throw new ArgumentException();
        }

        public bool ValidateMessage(string message)
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