using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ITrnstn3
{
    public class SecretKey
    {
        private const int KEY_LENGTH = 32;

        public byte[] Key { get; set; }

        public SecretKey()
        {
            Key = GenerateSecureRandomKey();
        }

        public static byte[] GenerateSecureRandomKey()
        {
            byte[] key = new byte[KEY_LENGTH];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }

        public string GetKey()
        {
            return BitConverter.ToString(Key).Replace("-", "").ToLower();
        }
    }
}
