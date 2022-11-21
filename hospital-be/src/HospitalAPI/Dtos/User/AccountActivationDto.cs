using System;

namespace HospitalAPI.Dtos.User
{
    public class AccountActivationDto
    {
        public Guid Token {  get; set; }
        public Guid Id { get; set; }
    }
}
