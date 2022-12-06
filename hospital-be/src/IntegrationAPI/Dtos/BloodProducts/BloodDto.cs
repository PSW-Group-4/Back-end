using IntegrationAPI.Dtos.BloodTypes;

namespace IntegrationAPI.Dtos.BloodProducts
{
    public class BloodDto
    {
        public BloodTypeDto BloodType { get; set; }
        public double Amount { get; set; }
        public BloodDto(BloodTypeDto bloodTypeDto, double amount)
        {
            BloodType = bloodTypeDto;
            Amount = amount;
        }

        public BloodDto() { }
    }
}
