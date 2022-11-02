using IntegrationLibrary.BloodBanks.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Utilities
{
    public interface IPasswordHandler
    {
        public String Generate();
        public String Hash(BloodBank bloodBank, String password);
        public PasswordVerificationResult Verify(BloodBank bloodBank, String providedPassword);
    }
}
