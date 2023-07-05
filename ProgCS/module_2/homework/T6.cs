using System;

namespace T6
{
    public class MyClassmate
    {
        readonly string name = "Unknown";
        readonly int birthYear = 1999;
        const int studyear = 4;
        static int enterYear = 2016;

        static MyClassmate()
        {
            enterYear = 2015;
        }

        public MyClassmate() { }

        public MyClassmate(string name, int by)
        {
            this.name = name;
            this.birthYear = by;
        }

        public string Information()
        {
            return "Name: " + name + ";\n" + "Age: " + (enterYear - birthYear) +
                " years old;\n" + $"End in {enterYear + studyear} year . . .";
        }
    }

    class Program
    {
        static void Main()
        {
            var nan = new MyClassmate();
            Console.WriteLine(nan.Information());
            var bob = new MyClassmate("Bob", 1980);
            Console.WriteLine(bob.Information());
            Console.ReadKey();
        }
    }
}
