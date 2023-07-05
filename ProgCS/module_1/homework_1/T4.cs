using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("U = ");
            double U = Convert.ToDouble(Console.ReadLine());
            Console.Write("R = ");
            double R = Convert.ToDouble(Console.ReadLine());
            double P = U * U / R;
            Console.WriteLine("P = " + P.ToString("G2"));
            Console.ReadLine();
        }
    }
}
