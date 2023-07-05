using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Task1Lib;

namespace Task12
{
    public class T2
    {
        public static void Main()
        {
            do
            {
                Console.Clear();

                string path = @"..\..\..\MyTest.txt";
                if (!File.Exists(path))
                {
                    Console.WriteLine($"Can't find file : {path}");
                    Console.ReadKey();
                    return;
                }

                var timer = new Stopwatch();
                timer.Start();
                string[] data = File.ReadAllLines(path);
                var pointsList = new List<ColorPoint>();
                int n = data.Length;
                for (int i = 0; i < n; i++)
                    pointsList.Add(GetObj(data[i]));

                timer.Stop();
                Console.WriteLine($"{n} lines read from: {path}");

                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// This method gets a ColorPoint from string
        /// </summary>
        /// <param name="str">line with ColorPoint data</param>
        /// <returns></returns>
        private static ColorPoint GetObj(string str)
        {
            char[] sep = { ' ' };
            var data = str.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (data.Length != 3)
                throw new ArgumentException("Invalid file format");

            ColorPoint obj = new ColorPoint();
            if (!double.TryParse(data[0], out obj.x))
                throw new ArgumentException("Invalid x in file objects");

            if (!double.TryParse(data[1], out obj.y))
                throw new ArgumentException("Invalid y in file objects");

            obj.color = data[2];

            return obj;
        }
    }
}
