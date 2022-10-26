using IntegrationLibrary.BloodBanks.Model;
using System;

namespace IntegrationAPI
{

    public class BloodBankRegisterDto
    {
        public string Name { get; set; }
        public string ServerAddress { get; set; }
        public string EmailAddress { get; set; }
    }
}
