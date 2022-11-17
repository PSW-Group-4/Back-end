using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dtos.BloodBank
{
    public class BloodBankEditDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ServerAddress { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
    }
}
