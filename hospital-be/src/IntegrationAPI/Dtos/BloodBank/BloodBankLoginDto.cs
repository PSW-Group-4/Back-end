namespace IntegrationAPI.Dtos.BloodBank
{
    public record BloodBankLoginDto
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}