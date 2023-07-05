using System;
using System.Collections.Generic;

namespace SR
{
    public partial class Program
    {
        [Serializable]
        public class Student
        {
            private static Random rnd = new Random();

            private string name;
            
            private string surname;
            
            private List<ControlElement> works;
            
            public Student(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                works = new List<ControlElement>();
                FillList(rnd.Next(5, 11), works);

            }

            public Student() { }

            private void FillList(int count, List<ControlElement> list)
            {
                for (int i = 0; i < count; i++)
                {
                    int coin = rnd.Next(1, 3);
                    if (coin == 1)
                        list.Add(new ControlWork(rnd.Next(0, 80) + rnd.NextDouble(),
                            GetName(), GetVariant()));
                    else
                        list.Add(new Contest(rnd.Next(0, 80) + rnd.NextDouble(),
                            GetName(), rnd.Next(1, 11)));
                }
            }

            private static int GetVariant()
            {
                int n = -1;
                while (n <= 0)
                    n = rnd.Next();
                return n;
            }

            private static string GetName()
            {
                return "adisjd";
            }
        }
    }
}
