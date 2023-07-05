using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        string str = File.ReadAllText($"input/{args[0]}");
        (int sum1, int sum2) = ArraySum(CalculateFirstArray(str), CalculateSecondArray(str));
        File.WriteAllText($"output/{args[1]}", $"{sum1 + sum2} {sum2} {sum1}");

    }

    public static int[] CalculateFirstArray(string str)
    {
        int n = str.Length,
            l = 0, r = -1;
        int[] d1 = new int[n];
        for (int i = 0; i < n; ++i)
        {
            int k = i > r ? 1 : Math.Min(d1[l + r - i], r - i + 1);
            while (i + k < n && i - k >= 0 && str[i + k] == str[i - k])
                ++k;
            d1[i] = k;
            if (i + k - 1 > r)
            {
                l = i - k + 1;
                r = i + k - 1;
            }
        }

        return d1;
    }

    public static int[] CalculateSecondArray(string str)
    {
        int n = str.Length,
            l = 0,
            r = -1;
        int[] d2 = new int[n];
        for (int i = 0; i < n; ++i)
        {
            int k = i > r ? 0 : Math.Min(d2[l + r - i + 1], r - i + 1);
            while (i + k < n && i - k - 1 >= 0 && str[i + k] == str[i - k - 1])
                ++k;
            d2[i] = k;
            if (i + k - 1 > r)
            {
                l = i - k;
                r = i + k - 1;
            }
        }

        return d2;
    }

    public static (int, int) ArraySum(int[] d1, int[] d2)
    {
        int sum1 = 0,
            sum2 = 0;
        for (int i = 0; i < d1.Length; i++)
        {
            sum1 += d1[i];
            sum2 += d2[i];
        }

        return (sum1, sum2);
    }
}
