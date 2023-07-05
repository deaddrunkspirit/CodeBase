using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* Группа:     БПИ196
 * Имя:        Мосолков Евгений Николаевич
 * Вариант:    12
 * Дисциплина: Програмирование
 */
namespace _2
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("To continue press any key...");
                while (Console.ReadKey().Key != ConsoleKey.Escape)
                /// цикл для повторения программы пока пользователь не нажмет Escape
                {
                    Console.Clear();
                    
                    int k = GetIntNumber(); /// ввод k
                    double[] arr = CreateArray(k); /// создание массива
                    string res1 = ShowArray(arr);
                    arr = ShiftArray(arr);
                    string res2 = ShowArray(arr);
                    string path = @"../../../HHHHH.txt";
                    File.WriteAllText(path, res1 + Environment.NewLine + res2);
                    Console.WriteLine("To exit press Escape");
                    Console.WriteLine("To continue press any key");
                }
            }
            /// Проверка всевозможных исключений
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);
            }
        }

        /// <summary>
        /// метод который удаляет все отрицательные
        /// значения а звтем сдвигает массив в право
        /// </summary>
        /// <param name="arr">массив в котором происходит сдвиг</param>
        static double[] ShiftArray(double[] arr)
        {
            SortArray(arr); /// сортируем массив по возрастанию 

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 0;
                }
            }

            return arr;
        }

        /// <summary>
        /// Метод для сортировки массива
        /// </summary>
        /// <param name="arr">массив который надо отсортировать</param>
        static void SortArray(double[] arr)
        {
            int b;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        arr[i] += arr[j];
                        arr[j] = arr[i] - arr[j];
                        arr[i] -= arr[j];
                    }
                }
            }
        }

        /// <summary>
        /// Метод для перевода массива в строку
        /// </summary>
        /// <param name="arr">массив который переводим в строку</param>
        /// <returns></returns>
        private static string ShowArray(double[] arr)
        {
            string res = "";
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                res += arr[i].ToString("f4") + " ";
                if (j == 7)
                {
                    res += Environment.NewLine;
                }
                j++;
            }

            return res;
        }

        /// <summary>
        /// Метод создающий массив длинны k из элементов заданной
        /// последовательности
        /// </summary>
        /// <param name="k">количество элементов последовательности</param>
        private static double[] CreateArray(int k)
        {
            double[] arr = new double[k];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Math.Pow(-1, i + 1) / (i * 2 + 1);
            }

            return arr;
        }

        /// <summary>
        /// Метод возвращающий k - длинну массива
        /// </summary>
        private static int GetIntNumber()
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Wrong Input");
            }

            return n;
        }
    }
}
