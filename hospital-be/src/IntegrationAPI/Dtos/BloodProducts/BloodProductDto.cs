using IntegrationAPI.Dtos.BloodTypes;

namespace IntegrationAPI.Dtos.BloodProducts
{
    public class BloodProductDto
    {
        public BloodTypeDto BloodType { get; set; }
        public double Amount { get; set; }
        public BloodProductDto(BloodTypeDto bloodTypeDto, double amount)
        {
            BloodType = bloodTypeDto;
            Amount = amount;
        }

        public BloodProductDto() { }
    }
}
