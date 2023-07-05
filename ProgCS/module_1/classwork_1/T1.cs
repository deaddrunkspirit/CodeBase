using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    class Program
    {
        public static void Main()
        {
            if (!int.TryParse(Console.ReadLine(), out int A) || A < 0)
            {
                Console.WriteLine("wrong");
                return;
            }
            if (!int.TryParse(Console.ReadLine(), out int B) || A < 0)
            {
                Console.WriteLine("wrong");
                return;
            }
        }

        static void Compare2Numbers(ref int A, ref int B)
        {
            if (A < B)
            {
                A += B;
                B = A - B;
                A -= B;
            }
        }

        static void GCF__and__LCM(int A, int B)
        {
            int i = 1;
            int greaestCommonF,
                leastCommonMultiple;
            while (i < A)
            {

            }
        }
    }
}
