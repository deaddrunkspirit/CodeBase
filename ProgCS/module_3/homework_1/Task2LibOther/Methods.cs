using System;

namespace Task2LibOther
{
    public class Methods
    {
        public static int[] ArrayOfDigits(int number)
        {
            string num = number.ToString();
            int[] digits = new int[num.Length];
            for (int i = 0; i < num.Length; i++)
                digits[i] = (int)num[i];
            return digits;
        } 

        public static void PrintIntArray(int[] digits)
        {
            foreach (int number in digits)
                Console.Write($"{number} ");
        }
    }
}
