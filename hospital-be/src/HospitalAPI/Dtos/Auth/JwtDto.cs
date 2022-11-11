namespace HospitalAPI.Dtos.Auth
{
    public class JwtDto
    {
        public string Jwt { get; set; }

        public JwtDto(string jwt)
        {
            Jwt = jwt;
        }
    }
}