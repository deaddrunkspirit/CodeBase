using System;

/* ФИО:         Мосолков Евгений Николаевич 
 * Группа:      БПИ196_2
 * Вариант:     12
 */


namespace SRClass
{
    public class Program
    {
        private static Random rnd = new Random();

        public static void Main()
        {
            try
            {
                do
                {
                    Console.Clear();

                    int n = GetInt();
                    var meowArr = new string[n];
                    GenerateMeowArr(n, meowArr);

                    Cat[] catArr = GenerateCatArray(n, meowArr);

                    PrintCatArray(catArr);

                    Console.WriteLine("To exit press Escape");
                    Console.WriteLine("To continue press any key . . .");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception e) // catching unexpected errors 
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        /// <summary>
        /// This method generates meow array
        /// </summary>
        private static void GenerateMeowArr(int n, string[] meowArr)
        {
            for (int i = 0; i < n; i++)
            {
                meowArr[i] = GenerateString(n);
            }
        }

        /// <summary>
        /// This method generates string
        /// </summary>
        private static string GenerateString(int n)
        {
            string res = "";
            for (int i = 0; i < rnd.Next(2, n + 1); i++)
            {
                res += (char)rnd.Next('a', 'z');
            }

            return res;
        }

        /// <summary>
        /// This method prints an array of cats
        /// </summary>
        /// <param name="classArr">array of cats</param>
        private static void PrintCatArray(Cat[] catArr)
        {
            foreach (Cat item in catArr)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// This method generates an array of Cat type
        /// </summary>
        /// <param name="n">count of elements in array</param>
        /// <returns></returns>
        private static Cat[] GenerateCatArray(int n, string[] meowArr)
        {
            var classArr = new Cat[n];
            string name = "Cat";
            for (int i = 0; i < classArr.Length; i++)
            {
                classArr[i] = new Cat(name + $"{i + 1}", meowArr);
            }

            return classArr;
        }

        /// <summary>
        /// This method gets an integer number from user
        /// </summary>
        /// <param name="str">message for user</param>
        /// <param name="upper">upper bound of number</param>
        /// <param name="lower">lower bound of number</param>
        /// <returns></returns>
        private static int GetInt(string str = "Input n: ",
            int upper = Int32.MaxValue, int lower = 1)
        {
            int n;
            Console.Write(str);
            while (!int.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
            {
                Console.WriteLine($"Please input integer number in [{lower}, {upper}]");
            }

            return n;
        }
    }
}
