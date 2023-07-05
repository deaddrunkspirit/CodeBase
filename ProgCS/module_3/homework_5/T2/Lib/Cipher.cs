namespace Task2Lib
{
    internal interface Cipher
    {
        string Encrypt(string plainText);

        string Decrypt(string cipherText);
    }
}