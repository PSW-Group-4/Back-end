using IntegrationLibrary.BloodBanks.Model;
using Microsoft.AspNetCore.Identity;
using System;


namespace IntegrationLibrary.Utilities
{
    public class PasswordHandler : IPasswordHandler
    {
        private readonly IPasswordHasher<BloodBank> _passwordHasher;
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "123456789";
        const string SPECIALS = @"!@£$%^&*()#€";

        public PasswordHandler(IPasswordHasher<BloodBank> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string Generate()
        {
            char[] _password = new char[20];
            string charSet = "";
            System.Random _random = new Random();
            int counter;

            charSet += LOWER_CASE;

            charSet += UPPER_CASE;

            charSet += NUMBERS;

            charSet += SPECIALS;

            for (counter = 0; counter < 20; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return string.Join(null, _password);
        }

        
        public string Hash(BloodBank bloodBank, string password)
        {
            return _passwordHasher.HashPassword(bloodBank, password);
        }

        public PasswordVerificationResult Verify(BloodBank bloodBank, string providedPassword)
        {
            return _passwordHasher.VerifyHashedPassword(bloodBank, bloodBank.Password, providedPassword);
        }
    }


}
