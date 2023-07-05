using System;
using Task4Lib;

namespace Task4
{
    public class T4
    {
        /// <summary>
        /// Main plot of the programm
        /// </summary>
        public static void Main()
        {
            do
            { 
                Robot rob = new Robot();
                Steps[] trace = { new Steps(rob.Backward), new Steps(rob.Forward),
                new Steps(rob.Left), new Steps(rob.Right)};

                //// First part of the task
                //for (int i = 0; i < trace.Length; i++)
                //{
                //    Console.WriteLine($"Method={trace[i].Method}, Target={trace[i].Target}");
                //    trace[i]();
                //}
                //Console.WriteLine(rob.Position());

                // Getting coordinates and pointing start position of robot
                int x = GetInt("X size: "), y = GetInt("Y size: ");
                char[,] field = GetField(x, y);
                field[rob.X, rob.Y] = '*';
                Console.WriteLine($"Start: { rob.Position()}");
                PrintField(field);

                // Executing program
                try
                {
                    string progStr = GetRobotProg();
                    Steps prog = rob.Right;
                    ExecuteProgram(rob, field, progStr, prog - rob.Right);

                    // End position
                    field[rob.X, rob.Y] = '*';
                    Console.WriteLine("Position after program:");
                    PrintField(field);
                    Console.WriteLine(rob.Position());
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Program is incorrect. Robot cannot go outside field!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong!\n" + e.Message);
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// This method Executes program
        /// </summary>
        /// <param name="rob">Robot</param>
        /// <param name="field">Field for robot to walk</param>
        /// <param name="progStr">string of latin uppercase letters: L, R, B, F (program in string)</param>
        /// <param name="prog">delegate with commands for robot</param>
        /// <returns></returns>
        private static void ExecuteProgram(Robot rob, char[,] field, string progStr, Steps prog)
        {
            int cx = 0, cy = 0;
            foreach (char l in progStr)
            {
                if (l == 'R')
                {
                    field[rob.X, rob.Y] = '+';
                    prog += rob.Right;
                    cx++;
                }
                else if (l == 'L')
                {
                    field[rob.X, rob.Y] = '+';
                    prog += rob.Left;
                    cx--;
                }
                else if (l == 'B')
                {
                    field[rob.X, rob.Y] = '+';
                    prog += rob.Backward;
                    cy--;
                }
                else if (l == 'F')
                {
                    field[rob.X, rob.Y] = '+';
                    prog += rob.Forward;
                    cy++;
                }
                else
                    Console.WriteLine("Something went wrong");
                field[cx, cy] = '+';
            }
            prog();
        }

        /// <summary>
        /// This method prints field with marks on places where robot is and was
        /// </summary>
        private static void PrintField(char[,] field)
        {
            for (int j = field.GetLength(0) - 1; j >= 0; j--, Console.WriteLine())
                for (int i = 0; i < field.GetLength(1); i++)
                    if (field[i, j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{field[i, j]} ");
                        Console.ResetColor();
                    }
                    else if (field[i, j] == '+')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"{field[i, j]} ");
                        Console.ResetColor();
                    }
                    else
                        Console.Write($"{field[i, j]} ");
        }

        /// <summary>
        /// This method creates a field with char symbol '_'
        /// </summary>
        /// <param name="x">length of x axis</param>
        /// <param name="y">length of y axis</param>
        /// <returns></returns>
        private static char[,] GetField(int x, int y)
        {
            char[,] field = new char[x, y];
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                    field[i, j] = '_';
            return field;
        }

        /// <summary>
        /// This methog gets an integer number from user
        /// </summary>
        /// <param name="mes">message for user</param>
        /// <param name="lower">lower bound of the number value</param>
        /// <param name="upper">upper bount of the number value</param>
        /// <returns></returns>
        private static int GetInt(string mes = "Input n: ", int lower = 0, int upper = int.MaxValue)
        {
            int n;
            Console.Write(mes);
            while (!int.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
                Console.WriteLine($"Please input integer number in [{lower}, {upper}]");
            return n;
        }

        /// <summary>
        /// This method gets a program for robot from user
        /// </summary>
        /// <param name="mes">Message for user</param>
        /// <returns></returns>
        private static string GetRobotProg(string mes = "Input programm for robot: ")
        {
            string s = "Your input is incorrect!";
            Console.Write(mes);
            bool flag = false;
            do
            {
                s = Console.ReadLine();
                foreach (char letter in s)
                    if (letter == 'R' || letter == 'L' || letter == 'F' || letter == 'B')
                        flag = true;
                    else
                        flag = false;
                if (!flag)
                    Console.WriteLine("Incorrect input");
            } while (!flag);
            return s;
        }
    }
}
