using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Model
{
    public class BloodBank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ServerAddress { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
    }
}
