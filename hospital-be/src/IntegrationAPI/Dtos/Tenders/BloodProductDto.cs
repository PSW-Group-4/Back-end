namespace IntegrationAPI.Dtos.Tenders
{
    public class BloodProductDto
    {
        public string BloodType { get; set; }
        public double Amount { get; set; }
        public BloodProductDto(string bloodType, double amount)
        {
            BloodType = bloodType;
            Amount = amount;
        }

        public BloodProductDto() { }
    }
}
