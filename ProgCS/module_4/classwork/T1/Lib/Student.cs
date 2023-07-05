using System;

namespace Task1Lib
{
    [Serializable]
    public class Student
    {
        public string name;
        
        public int year;
        
        public Student(string name, int year)
        {
            this.name = name;
            this.year = year;
        }

        public Student() { }
    }
}
