using System;
using System.Diagnostics;
using Task1Lib;

namespace Task1
{
    public class T1
    {
        private static Random rnd = new Random();

        private const int N = 100000;

        public static void Main()
        {
            do
            {
                Console.Clear();

                TestClass[] tc = new TestClass[N];
                TestStruct[] ts = new TestStruct[N];
                for (int i = 0; i < N; i++)
                {
                    tc[i] = new TestClass();
                    int tmp = rnd.Next();
                    tc[i].X = tmp;
                    ts[i].x = tmp;
                }
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Array.Sort(ts);
                sw.Stop(); PrintTime(sw.Elapsed);
                sw.Start();
                Array.Sort(tc);
                sw.Stop(); PrintTime(sw.Elapsed);

                Console.Beep();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void PrintTime(TimeSpan timeSpan)
        {
            string elapsedTime = $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:" +
                $"{timeSpan.Seconds:00}:{timeSpan.Milliseconds / 10:00}";
            Console.WriteLine($"Struct time\nRuntime {elapsedTime}");
        }
    }
}