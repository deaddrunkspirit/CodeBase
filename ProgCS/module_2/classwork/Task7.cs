using System;

namespace Task7
{
    class Program
    {
        static string[] branches = { "Western", "Central", "Eastern" };

        static string[] quarter = { "I", "II", "III", "IV" };

        static int[,] auto = { { 20, 24, 25 },  // I
                               { 21, 20, 18 },  // II
                               { 23, 27, 24 },  // III
                               { 22, 19, 20 } };// IV

        static void Main()
        {
            try
            {
                do
                {
                    Console.Clear();
                    int yearSale = AllYearSales(); //1 counts the amount of auto sold in 4 quaters
                    MaxForQuater(); //2 the number of maximum sold cars for any branch
                    Console.WriteLine($"{SuccessfullBranch()} is the most successfull branch"); //3
                    SuccessfullQuater(); //4


                    Console.WriteLine("To exit press ESCAPE");
                    Console.WriteLine("To continue press any key . . .");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }

        private static void SuccessfullQuater()
        {
            int totalI = 0, totalII = 0, totalIII = 0, totalIV = 0;
            for (int i = 0; i < auto.GetLength(0); i++)
            {
                for (int j = 0; j < auto.GetLength(1); j++)
                {
                    switch (i)
                    {
                        case 0:
                            totalI += auto[i, j];
                            break;
                        case 1:
                            totalII += auto[i, j];
                            break;
                        case 2:
                            totalIII += auto[i, j];
                            break;
                        case 3:
                            totalIV += auto[i, j];
                            break;
                    }
                }
            }
            string res = "";
            int max = Math.Max(totalI,
                (Math.Max(totalII, Math.Max(totalIII, totalIV))));
            res = max == totalI ? res = "I" : totalII == max ? res = "II" :
                totalIII == max ? res = "III" : res = "IV";
            Console.WriteLine($"In {res} quater was sold {max} autos");
        }

        private static string SuccessfullBranch()
        {
            int totalW = 0, totalC = 0, totalE = 0;
            for (int i = 0; i < auto.GetLength(0); i++)
            {
                for (int j = 0; j < auto.GetLength(1); j++)
                {
                    switch (j)
                    {
                        case 0:
                            totalW += auto[i, j];
                            break;
                        case 1:
                            totalC += auto[i, j];
                            break;
                        case 2:
                            totalE += auto[i, j];
                            break;
                    }
                }
            }
            return MaxForYear(totalW, totalC, totalE);
        }

        private static string MaxForYear(int totalW, int totalC, int totalE)
        {
            if (totalC > totalW)
            {
                if (totalC > totalE)
                {
                    return "Central";
                }
                else
                {
                    return "Eastern";
                }
            }
            else
            {
                if (totalW > totalE)
                {
                    return "Western";
                }
                else
                {
                    return "Eastern";
                }
            }
        }

        private static void MaxForQuater()
        {
            Console.WriteLine("Choose branch:");
            Console.WriteLine("1 - Western");
            Console.WriteLine("2 - Central");
            Console.WriteLine("3 - Eastern");
            int column = GetQuaterNumber();
            int maxSold = MaxSoldInBranch(column);
            string branch = "";
            switch (column)
            {
                case 1:
                    branch = "Western";
                    break;
                case 2:
                    branch = "Central";
                    break;
                case 3:
                    branch = "Eastern";
                    break;
            }
            Console.WriteLine($"{branch} branch's maximum sold - {maxSold} auto");
        }

        private static int MaxSoldInBranch(int row)
        {
            int maxSold = -1;
            for (int i = 0; i < auto.GetLength(0); i++)
            {
                if (maxSold > auto[i, row - 1])
                {
                    maxSold = auto[i, row - 1];
                }
            }

            return maxSold;
        }

        private static int GetQuaterNumber()
        {
            int column;
            while (!int.TryParse(Console.ReadLine(), out column) || column < 1 || 3 < column)
            {
                Console.WriteLine("Choose number from [1, 2, 3] (it is a column of branch sales)");
            }

            return column;
        }

        /// <summary>
        /// This method counts automobiles 
        /// which 3 filials sold in year 
        /// </summary>
        /// <returns></returns>
        private static int AllYearSales()
        {
            int res = 0;
            for (int i = 0; i < auto.GetLength(0); i++)
            {
                for (int j = 0; j < auto.GetLength(1); j++)
                {
                    res += auto[i, j];
                }
            }

            return res;
        }
    }
}
