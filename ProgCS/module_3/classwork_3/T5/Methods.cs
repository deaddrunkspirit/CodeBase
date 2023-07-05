using System;

public delegate void LineCompleteEvent();
public delegate void ItemEvents(int[,] arr);

namespace Task5Lib
{
    public class Methods
    {
        private static Random rnd = new Random();

        public static event LineCompleteEvent lineComplete;

        public static event ItemEvents newItemFilled;

        public static void ArraySumCount(int[,] arr)
        {
            int sum = 0;
            foreach (int num in arr)
                sum += num;
            Console.WriteLine($"Sum of elements {sum}");
        }

        public static void ChangeMax(int[,] arr)
        {
            int max = int.MinValue;
            foreach (int num in arr)
                if (num != 0 && max < num)
                    max = num;
            Console.WriteLine($"Max element was {max}");
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
                for (int j = 0; j < arr.GetUpperBound(1); j++)
                    if (arr[i, j] == max)
                    {
                        arr[i, j] = rnd.Next(100);
                        Console.WriteLine($"Now this element is {arr[i, j]}");
                    }
        }

        public static void MidVal(int[,] arr)
        {
            int count = 0, sum = 0;
            foreach (int num in arr)
                count += 1;
            foreach (int num in arr)
                sum += num;
            Console.WriteLine($"Middle value: {sum / count}");
        }

        public static void ArrayPrint(int[,] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j < arr.GetUpperBound(1); j++)
                    Console.Write($"{arr[i, j]}\t");
                lineComplete();
            }
        }

        public static void ArrayFill(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(100);
                    newItemFilled(arr);
                }
        }
    }
}
