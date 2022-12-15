using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Model
{
    [Table("blood_banks")]
    public class BloodBank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ServerAddress { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
        public bool Activated { get; set; }

        public BloodBank(Guid id, string name, string serverAddress, string emailAddress, string password, string apiKey)
        {
            Id = id;
            Name = name;
            ServerAddress = serverAddress;
            EmailAddress = emailAddress;
            Password = password;
            ApiKey = apiKey;
            Activated = false;
        }
        
        public BloodBank(Guid id, string name, string serverAddress, string emailAddress, string password, string apiKey, bool activated)
        {
            Id = id;
            Name = name;
            ServerAddress = serverAddress;
            EmailAddress = emailAddress;
            Password = password;
            ApiKey = apiKey;
            Activated = activated;
        }

        public BloodBank() { }

    }
}
