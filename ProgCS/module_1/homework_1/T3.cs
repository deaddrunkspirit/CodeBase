using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the number from 32 to 127 to get your symbol");
            int symb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine((char)symb);
            Console.ReadLine();
        }
    }
}
