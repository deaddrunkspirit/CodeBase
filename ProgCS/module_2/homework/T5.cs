using System;

namespace T5
{
    public class ConsolePlate
    {
        char _plateChar;
        ConsoleColor _plateColor = ConsoleColor.White;
        ConsoleColor _backColor = ConsoleColor.Black;

        public ConsolePlate()
        {
            _plateChar = 'A';
        }

        public ConsolePlate(char plateChar, ConsoleColor plateColor, ConsoleColor backColor)
        {
            this.PlateChar = plateChar;
            this.PlateColor = plateColor;
            this.BackColor = backColor;
        }

        public char PlateChar
        {
            get { return _plateChar; }
            set
            {
                if (value > 'A' || value < 'Z' + 1)
                {
                    _plateChar = value;
                }
                else
                {
                    _plateChar = 'A';
                }
            }
        }

        public ConsoleColor BackColor
        {
            get 
            {
                return _backColor;
            }
            set
            {
                if (value != _plateColor)
                    _backColor = value;
                else
                    _backColor = ConsoleColor.Black;
            }
        }

        public ConsoleColor PlateColor
        {
            get { return _plateColor; }
            set { _plateColor = value; }
        }
    }

    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();

                int n = GetInt("Input n: ");

                var cp1 = new ConsolePlate('X', ConsoleColor.White, ConsoleColor.Red);
                var cp2 = new ConsolePlate('O', ConsoleColor.White, ConsoleColor.Magenta);
                ConsolePlate[] somePlates = { cp1, cp2 };
                for (int i = 0; i < n; i++, Console.WriteLine())
                {
                    for (int j = 0; j < n; j++)
                    {
                        foreach (ConsolePlate conPl in somePlates)
                        {
                            Console.ForegroundColor = conPl.PlateColor;
                            Console.BackgroundColor = conPl.BackColor;
                            Console.Write(conPl.PlateChar);
                        }
                    }
                }

                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("To exit press Escape");
                Console.WriteLine("To continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static int GetInt(string str)
        {
            Console.Write(str);
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 2 || n > 34)
            {
                Console.WriteLine("Wrong input");
            }

            return n;
        }

        private static char GetChar(string str)
        {
            char s;
            Console.Write(str);
            while (!char.TryParse(Console.ReadLine(), out s) || s < 'A' || s > 'Z')
            {
                Console.WriteLine("Input char in [A, Z]");
            }

            return s;
        }
    }
}
