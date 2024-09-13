using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ITrnstn3
{
    public class Hmac
    {
        public byte[] SecretKey { get; set; }

        public Hmac(SecretKey secretKey)
        {
            SecretKey = secretKey.Key;
        }

        public string CalculateHmac(string message)
        {
            using (HMACSHA256 hmac = new HMACSHA256(SecretKey))
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                byte[] hmacBytes = hmac.ComputeHash(messageBytes);

                return BitConverter.ToString(hmacBytes).Replace("-", "").ToLower();
            }
        }

        public string GetHmac(string message)
        {
            return CalculateHmac(message);
        }
    }
}
