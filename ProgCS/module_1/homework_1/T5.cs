using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input cathets to find hypotenuse.");
            Console.Write("The first cathet is: ");
            double FirstCathet = Convert.ToDouble(Console.ReadLine());
            Console.Write("The second cathet is: ");
            double SecondCathet = Convert.ToDouble(Console.ReadLine());
            double Hypotenuse = Math.Sqrt(FirstCathet * FirstCathet + SecondCathet * SecondCathet);
            Console.Write("The hypotenuse is: " + Convert.ToString(Hypotenuse));
            Console.ReadLine();
        }
    }
}
