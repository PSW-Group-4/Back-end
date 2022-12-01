using IntegrationAPI.Dtos.BloodTypes;
using IntegrationLibrary.Common;

namespace IntegrationAPI.Dtos.BloodProducts
{
    public class BloodProductConverter
    {
        public static BloodProduct Convert(BloodProductDto bloodProductDto)
        {
            return new BloodProduct(BloodTypeConverter.Convert(bloodProductDto.BloodType), bloodProductDto.Amount);
        }
    }
}
