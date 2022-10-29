using IntegrationLibrary.BloodBanks.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IntegrationLibrary.Utilities
{
    public class PasswordHandler : PasswordHasher<BloodBank>
    {

        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "123456789";
        const string SPECIALS = @"!@£$%^&*()#€";

        public static string GeneratePassword(bool useLowercase = true, bool useUppercase = true, bool useNumbers = true, bool useSpecial = true,
                int passwordSize = 20)
        {

            char[] _password = new char[passwordSize];
            string charSet = "";
            System.Random _random = new Random();
            int counter;

            if (useLowercase) charSet += LOWER_CASE;

            if (useUppercase) charSet += UPPER_CASE;

            if (useNumbers) charSet += NUMBERS;

            if (useSpecial) charSet += SPECIALS;

            for (counter = 0; counter < passwordSize; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return String.Join(null, _password);
        }
    }


}
