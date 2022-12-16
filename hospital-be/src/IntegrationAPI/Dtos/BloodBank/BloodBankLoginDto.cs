namespace IntegrationAPI.Dtos.BloodBank
{
    public record BloodBankLoginDto
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }
}