using IntegrationAPI.Dtos.BloodProducts;

namespace IntegrationAPI.Dtos.BloodSubscription
{
    public class SubscriptionConverter
    {
        public static BloodSubscriptionSendingDto Convert(IntegrationLibrary.BloodSubscriptions.BloodSubscription subscription)
        {
            var retVal = new BloodSubscriptionSendingDto();
            retVal.bloodBank = subscription.BloodBankName;
            retVal.blood = BloodConverter.Convert(subscription.Blood);
            retVal.SubscriptionId = subscription.Id;
            return retVal;
        }

        public static IntegrationLibrary.BloodSubscriptions.BloodSubscription Convert(BloodSubscriptionCreatingDto dto)
        {
            var retVal = new IntegrationLibrary.BloodSubscriptions.BloodSubscription(dto.BloodBank);
            if(dto.ActiveStatus == true)
            {
                retVal.Activate();
            }
            else
            {
                retVal.Deactivate();
            }
            foreach(var item in dto.Blood)
            {
                if(item != null)
                {
                    retVal.AddBloodType(BloodConverter.Convert(dto.Blood));
                }
            }
            if(dto.Urgent == true)
            {
                retVal.MakeUrgent();
            }
            else
            {
                retVal.MakeNotUrgent();
            }
            return retVal;
        }
    }
}
