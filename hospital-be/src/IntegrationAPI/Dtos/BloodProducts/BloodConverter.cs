using IntegrationAPI.Dtos.BloodTypes;
using IntegrationLibrary.Common;

namespace IntegrationAPI.Dtos.BloodProducts
{
    public class BloodConverter
    {
        public static Blood Convert(BloodDto bloodDto)
        {
            return new Blood(BloodTypeConverter.Convert(bloodDto.BloodType), bloodDto.Amount);
        }
    }
}
