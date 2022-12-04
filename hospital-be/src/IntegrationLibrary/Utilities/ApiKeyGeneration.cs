using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Utilities
{
    public class ApiKeyGeneration
    {
        public static string generateKey()
        {
            string keyString;
            var key = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            keyString = Convert.ToBase64String(key);
            keyString = keyString.Replace('+', '-').Replace('/', '_').Replace('=', '8');

            return keyString;
        }
    }
}
