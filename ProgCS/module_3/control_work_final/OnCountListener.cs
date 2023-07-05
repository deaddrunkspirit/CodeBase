using System;

namespace MyClassLibrary
{
    public class OnCountListener
    {
        public int _k;

        public OnCountListener(int k)
        {
            _k = k;
        }

        public void OnCount(int num)
        {
            if (num % _k == 0)
                Console.WriteLine($"Current num is {num}");
        }
    }
}