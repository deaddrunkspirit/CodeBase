using System;
using System.IO;

namespace FirstSem
{
    class Program
    {
        static void Main()
        {
            do
            {
                string path = @"../../../RESULT.txt";
                int[,] matrix = new int[3, 4] { { 0, 1, 3, 4 }, { 5, 6, 7, 8 }, { 9, -1, -2, -3 } };
                string res = "";
                res += "GetType() = " + matrix.GetType() + Environment.NewLine;
                res += "IsFixedSize() = " + matrix.IsFixedSize + Environment.NewLine;
                res += "Rank() = " + matrix.Rank + Environment.NewLine;
                res += "Length() = " + matrix.Length + Environment.NewLine;
                res += "GetLength(1) = " + matrix.GetLength(1) + Environment.NewLine;
                res += "GetUpperBound(1) = " + matrix.GetUpperBound(1) + Environment.NewLine;

                Console.WriteLine(res);
                Console.WriteLine("" + Environment.NewLine + Environment.NewLine);
                try
                {
                    File.WriteAllText(path, res);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error with file output");
                    Console.WriteLine("Error: " + ex.Message + Environment.NewLine + "To exit press any key . . .");
                    Console.ReadKey();
                }

                foreach (int memb in matrix)
                    Console.Write("{0,3}", memb);

                Console.WriteLine("\n");

                for (int i = 0; i < matrix.GetLength(0); i++, Console.WriteLine())
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        Console.Write("{0,3}", matrix[i, j]);

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}
