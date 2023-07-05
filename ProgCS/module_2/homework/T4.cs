using System;

namespace T4
{
    public class HexNumber
    {
        uint number;

        char[] hexView;

        public HexNumber(uint n)
        {
            number = n;
            hexView = series(n);
        }

        public HexNumber() : this(0) { }

        public uint Number
        {
            get { return number; }
            set
            {
                number = value;
                hexView = series(value);
            }
        }

        public char[] HexView
        {
            get { return hexView; }
        }

        public string Record
        {
            get
            {
                string str = new String(hexView);
                return "0x" + str;
            }
        }

        char[] series(uint num)
        {
            int arLen = num == 0 ? 1 : (int)Math.Log(num, 16) + 1;
            char[] res = new char[arLen];
            for (int i = arLen - 1; i >= 0; i--)
            {
                uint temp = (uint)(num % 16);
                if (temp >= 0 && temp <= 9)
                {
                    res[i] = (char)('0' + temp);
                }
                else
                {
                    res[i] = (char)('A' + temp % 10);
                }
                num /= 16;
            }

            return res;
        }
    }

    class Program
    {
        static void Main()
        {
            var hex = new HexNumber();
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                uint number = GetUInt("Input positive integer: ");
                hex.Number = number;
                Console.WriteLine("Property Number: " + hex.Number);
                Console.WriteLine("Hexademical digits if number: ");
                foreach (char h in hex.HexView)
                    Console.Write("{0} ", h);

                Console.WriteLine($"{Environment.NewLine}Hexodemical view: " + hex.Record);

                Console.WriteLine("To exit press Escape");
                Console.WriteLine("To continue press any key . . .");
            }
        }

        private static uint GetUInt(string str)
        {
            uint number;
            Console.Write(str);
            while (!uint.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Incorrect input!");
            }

            return number;
        }
    }
}
