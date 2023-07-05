using System;

namespace Task2Lib
{
    public class CeaserCipher : Cipher
    {
        private int numberOfPositions;

        public CeaserCipher(int numberOfPositions)
        {
            if (numberOfPositions <= 0)
                throw new ArgumentException("Number of positions can't be negative!");
            this.numberOfPositions = numberOfPositions;
        }

        public string Decrypt(string cipherText)
        {
            string res = "";
            foreach (var letter in cipherText)
                if ()
        }

        public string Encrypt(string plainText)
        {
            throw new NotImplementedException();
        }
    }
}