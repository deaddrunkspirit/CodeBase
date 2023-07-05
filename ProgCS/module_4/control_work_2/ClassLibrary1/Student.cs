using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    [Serializable]
    public class Student
    {
        private static Random rnd = new Random();

        public string Name { get; set; }

        public string Surname { get; set; }

        private ControlElement[] works;

        public Student() { }

        public Student(string name, string surname)
        {
            int length = rnd.Next(5, 11);
            works = new ControlElement[length];
            for (int i = 0; i < length; i++)
                AddElement(rnd.Next(1, 3), works, i);

            Name = name;
            Surname = surname;
        }

        private static void AddElement(int choice, ControlElement[] works, int number)
        {
            switch (choice)
            {
                case 1:
                    works[number] = new ControlWork(rnd.Next(100), rnd.Next(80), GetString(2, 12));
                    break;
                case 2:
                    works[number] = new Contest(rnd.Next(1, 11), rnd.Next(80), GetString(2, 12));
                    break;
            }
        }

        private static string GetString(int minLength, int maxLength)
        {
            string str = "" + (char)rnd.Next('А', 'Я' + 1);
            int length = rnd.Next(minLength, maxLength + 1);
            for (int i = 0; i < length - 1; i++)
                str += (char)rnd.Next('а', 'я' + 1);

            return str;
        }

        public override string ToString()
        {
            string res = $"Name: {Name}, Surname: {Surname}";
            for (int i = 0; i < works.Length; i++)
                res += works[i].ToString();

            return res;
        }
    }
}
