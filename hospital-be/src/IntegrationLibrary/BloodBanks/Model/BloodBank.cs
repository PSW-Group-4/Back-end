using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Model
{
    public class BloodBank
    {
        private Guid Id { get; set; }
        private string Name { get; set; }
        private string ServerAddress { get; set; }
        private string EmailAddress { get; set; }
        private string Password { get; set; }
        private string ApiKey { get; set; }
    }
}
