using IntegrationLibrary.Exceptions;
using IntegrationLibrary.BloodSubscriptionResponses.Model;

namespace IntegrationAPI.Dtos.BloodSubscriptionResponse
{
    public class BloodSubscriptionResponseConverter
    {
        public static IntegrationLibrary.BloodSubscriptionResponses.Model.BloodSubscriptionResponse Convert(IntegrationLibrary.BloodSubscriptions.BloodSubscription subscription, BloodSubscriptionResponseDto dto)
        {
            if (dto == null)
            {
                throw new NotFoundException();
            }
            IntegrationLibrary.BloodSubscriptionResponses.Model.BloodSubscriptionResponse retVal = new();
            retVal.SetSubscription(subscription);
            retVal.SetMessage(dto.MessageString);
            return retVal;
        }
    }
}
