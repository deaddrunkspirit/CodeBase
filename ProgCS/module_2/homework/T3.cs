using System;

namespace T3
{
    public class Polygon
    {
        int numb;
        double radius;

        public Polygon(int n = 3, double r = 1)
        {
            numb = n;
            radius = r;
        }

        public double Perimetr
        {
            get
            {
                return 2 * numb * radius * Math.Tan(Math.PI / numb);
            }
        }

        public double Area
        {
            get
            {
                return Perimetr * radius / 2;
            }
        }

        public string PolygonData()
        {
            string res = string.Format("N = {0}; R = {1}; P = {2,2:F3}; S = {3,4:F3}",
                numb, radius, Perimetr, Area);

            return res;
        }
    }


    class Program
    {
        static void Main()
        {
            var polygon = new Polygon();
            Console.WriteLine("Default polygon: ");
            Console.WriteLine(polygon.PolygonData());
            do
            {
                Console.Clear();

                int el = GetInt("Input the size of the array: ", "Please input integer in [1, 100]", 1, 100);
                Polygon[] polygonArr = GetPolygonArray(el);

                Console.WriteLine($"Choose which polygon data you want to see (in range from 1 to {el})");
                int polNum = GetInt("Input the number of polygon in array: ",
                    $"Please input number in [1, {el}]", 1, el + 1);

                polygon = polygonArr[polNum - 1];
                Console.WriteLine("Polygon data: ");
                Console.WriteLine(polygon.PolygonData());

                Console.WriteLine("To exit press Escape key");
                Console.WriteLine("To continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static Polygon[] GetPolygonArray(int el)
        {
            double rad;
            int num;
            var polygonArr = new Polygon[el];
            for (int i = 0; i < el; i++)
            {
                Console.WriteLine($"{i + 1} element of array data:");
                num = GetInt("Input count of sides: ",
                    "Please input integer number greater than 3", 3, Int32.MaxValue);
                rad = GetDouble("Input the radius: ",
                    "Plese input real number greater than 0");
                polygonArr[i] = new Polygon(num, rad);
            }

            return polygonArr;
        }

        private static double GetDouble(string str, string mes)
        {
            double rad;
            Console.Write(str);
            while (!double.TryParse(Console.ReadLine(), out rad) || rad < 0)
            {
                Console.WriteLine(mes);
            }

            return rad;
        }

        private static int GetInt(string str, string mes, int lower, int upper)
        {
            int el;
            Console.Write(str);
            while (!int.TryParse(Console.ReadLine(), out el) || el < lower || el > upper)
            {
                Console.WriteLine(mes);
            }

            return el;
        }
    }
}
