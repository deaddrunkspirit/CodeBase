using System;

namespace Task1Lib
{
    [Serializable]
    public class Group
    {
        public string id;

        public Student[] list;
        
        public Group(string id, Student[] list)
        {
            this.id = id;
            this.list = list;
        }

        public Group() { }

        public override string ToString()
        {
            string temp = id + ": ";
            foreach (var student in list)
                temp += $"{student.name}-{student.year} ";

            return temp;
        }
    }
}
