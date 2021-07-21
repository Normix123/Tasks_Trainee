using System;
using System.Security.Cryptography;

namespace Game
{
    public static class Hash
    {
        public static byte[] RandomNumberGenerator()
        {
            var b = new byte[16];
            new Random().NextBytes(b);
            return b;
        }

        public static byte[] HashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }
    }
}
