using IntegrationLibrary.ManagerBloodRequests.Model;
using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class ManagerBloodRequestConverter
    {
        public static ManagerBloodRequestDto Convert(ManagerRequest request)
        {
            ManagerBloodRequestDto retVal = new ManagerBloodRequestDto();
            retVal.id = request.Id;
            retVal.urgent = true;
            retVal.sendOnDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            retVal.bloodBank = request.BloodBank.Name;
            retVal.amount = request.Blood.Amount;
            retVal.bloodType = request.Blood.BloodType.ToString();
            return retVal;
        }
    }
}
