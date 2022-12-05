using IntegrationAPI.Dtos.BloodProducts;

namespace IntegrationAPI.Dtos.BloodSubscription
{
    public class SubscriptionConverter
    {
        public static BloodSubscriptionDto Convert(IntegrationLibrary.BloodSubscriptions.BloodSubscription subscription)
        {
            var retVal = new BloodSubscriptionDto();
            retVal.bloodBank = subscription.BloodBankName;
            retVal.blood = BloodConverter.Convert(subscription.Blood);
            retVal.SubscriptionId = subscription.Id;
            return retVal;
        }
    }
}
