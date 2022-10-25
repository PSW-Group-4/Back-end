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
        public static String generateKey(List<String> keyList)
        {
            String keyString;
            do
            {
                var key = new byte[32];
                using (var generator = RandomNumberGenerator.Create())
                    generator.GetBytes(key);
                keyString = Convert.ToBase64String(key);

            } while (!isUnique(keyList, keyString));

            return keyString;
        }

        private static Boolean isUnique(List<String> keyList, String newKey)
        {
            if(keyList == null || keyList.Count == 0)
            {
                return true;
            }
            else 
            {
                return keyList.Contains(newKey);
            }

        }
    }
}
