using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork2
{
    class Program
    { 
        // Я старался, но не смог сделать по красоте (заболел)
        static void Main(string[] args)
        {
            try
            {
                string input = args[2],
                    output = args[3],
                    outType = args[1],
                    direction = args[0];
                string[] data = File.ReadAllLines(input);
                int n = int.Parse(data[0]);
                Point[] pointsArray = new Point[n];
                for (int i = 1; i < data.Length; i++)
                    pointsArray[i - 1] = new Point(int.Parse(data[i].Split()[0]), int.Parse(data[i].Split()[1]));
                var stack = GrahamScan(pointsArray, n, direction);
                // Проход по часовой стрелке не реалиован
                // Вывод реализован только в формате plain
                switch (outType)
                {
                    case "wkt":
                        Console.WriteLine("Не успел реализовать(");
                        break;
                    case "plain":
                        File.WriteAllText(output, stack.Plain());
                        break;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }


        private static Stack GrahamScan(Point[] points, int n, string direction)
        {
            int yMin = points[0].Y, min = 0;
            for (int i = 1; i < n; i++)
            {
                int y = points[i].Y;
                if ((y < yMin) || (yMin == y && points[i].X < points[min].X))
                {
                    yMin = points[i].Y;
                    min = i;
                }
            }
            Swap(ref points[0], ref points[min]);
            QuickSort(points, 1, n - 1);
            int m = 1;
            for (int i = 1; i < n; i++)
            {
                while (i < n - 1 && CCW(points[0], points[i], points[i + 1]) == 0)
                    i++;
                points[m] = points[i];
                m++;
            }
            if (m < 3)
                throw new Exception("Convix hull is not possible");
            else
            {
                Stack stack = new Stack(m);
                stack.Push(points[0]);
                stack.Push(points[1]);
                stack.Push(points[2]);
                for (int i = 3; i < m; i++)
                {
                    while (stack.size() > 2 && CCW(stack.Top(), stack.nextToTop(), points[i]) != 2)
                        stack.Pop();
                    stack.Push(points[i]);
                }
                return stack;
            }
        }

        private static void Swap<T>(ref T p1, ref T p2)
        {
            T save = p1;
            p1 = p2;
            p2 = save;
        }

        static int Partition(Point[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        private static Point[] QuickSort(Point[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
                return array;

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        private static int CCW(Point p1, Point p2, Point p3)
        {
            double val = (p2.Y - p1.Y) * (p3.X - p2.X) - (p2.X - p1.X) * (p3.Y - p2.Y);
            if (val == 0)
                return 0;
            return val > 0 ? 1 : 2;
        }

        private static bool CW(Point p1, Point p2, Point p3)
            => ((p2.X - p1.X) * (p3.Y - p1.Y)) < ((p2.Y - p1.Y) * (p3.X - p1.X));
    }

    struct Point : IComparable
    {
        private int _x, _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X => _x;
        public int Y => _y;

        public static Point operator -(Point p1, Point p2)
            => new Point(p1.X - p2.X, p1.Y - p2.Y);

        public static Point operator +(Point p1, Point p2)
            => new Point(p1.X + p2.X, p1.Y + p2.Y);

        public static bool operator >(Point p1, Point p2)
        {
            if (p1.Y == 0 && p1.X > 0)
                return false;

            if (p2.Y == 0 && p2.X > 0)
                return true;

            if (p1.Y > 0 && p2.Y < 0)
                return false;

            if (p1.Y < 0 && p2.Y > 0)
                return true;

            return p1.X * p2.Y - p1.Y * p2.X < 0;
        }

        public static bool operator <(Point p1, Point p2)
        {
            if (p1.Y == 0 && p1.X > 0)
                return true;

            if (p2.Y == 0 && p2.X > 0)
                return false;

            if (p1.Y > 0 && p2.Y < 0)
                return true;

            if (p1.Y < 0 && p2.Y > 0)
                return false;

            return p1.X * p2.Y - p1.Y * p2.X > 0;
        }

        public int CompareTo(object obj)
            => this < (Point)obj ? -1 : this > (Point)obj ? 1 : 0;
    }

    class Stack
    {
        public List<Point> _data = new List<Point>();
        public const int MAX_STACK_SIZE = 1000;
        private int maxSize;

        public Stack(int max)
        {
            if (max >= MAX_STACK_SIZE)
                throw new ArgumentException("Invalid max size (greater than expected) . . .");
            maxSize = max;
        }

        public void Push(Point push)
        {
            if (_data.Count == maxSize)
                throw new ArgumentException("Stack is full . . .");
            _data.Add(push);
        }

        public void Pop()
        {
            if (isEmpty())
                throw new ArgumentException("Stack is empty . . .");
            _data.RemoveAt(_data.Count - 1);
        }

        public Point Top() => _data[_data.Count - 1];
        public Point nextToTop() => _data[_data.Count - 2];
        public int size() => _data.Count;
        public bool isEmpty() => _data is null;

        public string Plain()
        {
            string res = $"{_data.Count}";
            foreach (var item in _data)
                res += $"\n{item.X} {item.Y}";

            return res;
        }
    }
}
