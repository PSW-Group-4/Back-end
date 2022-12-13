using IntegrationAPI.Dtos.BloodProducts;
using IntegrationLibrary.BloodRequests.Model;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestSendConverter
    {
        public static BloodRequestSendDto Convert (BloodRequest request)
        {
            var retVal = new BloodRequestSendDto();
            retVal.Id = request.Id;
            retVal.BloodBank = request.BloodBank.Name;
            retVal.Blood = BloodConverter.Convert(request.Blood);
            return retVal;
        }
    }
}
