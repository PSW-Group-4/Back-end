namespace IntegrationAPI.Dtos.BloodTypes
{
    public class BloodTypeDto
    {
        public string BloodGroup { get; set; }
        public string RhFactor { get; set; }

        public BloodTypeDto() { }
        public BloodTypeDto(string bloodGroup, string rhFactor)
        {
            BloodGroup = bloodGroup;
            RhFactor = rhFactor;
        }
    }
}
