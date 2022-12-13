using IntegrationAPI.Dtos.BloodSubscription;
using IntegrationLibrary.BloodSubscriptionReponces.Model;
using IntegrationLibrary.BloodSubscriptionReponces.Service;
using IntegrationLibrary.BloodSubscriptions.Service;
using IntegrationLibrary.Exceptions;
using System;

namespace IntegrationAPI.Dtos.BloodSubscriptionResponce
{
    public class BloodSubscriptionResponceConverter
    {
        public static BloodSubscriptionRepsponce Convert(IntegrationLibrary.BloodSubscriptions.BloodSubscription subscription, BloodSubscriptionResponceDto dto)
        {
            if (dto == null)
            {
                throw new NotFoundException();
            }
            var retVal = new BloodSubscriptionRepsponce();
            retVal.SetSubscription(subscription);
            retVal.SetMessage(dto.MessageString);
            return retVal;
        }
    }
}
