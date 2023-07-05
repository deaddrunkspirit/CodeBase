using System;
using System.Collections.Generic;

namespace Task2Lib
{
    [Serializable]
    public class Dept
    {
        public List<Human> Staff { get; set; }

        public string DeptName { get; set; }

        public Dept() { }

        public Dept(string name, Human[] staffList)
        {
            DeptName = name;
            Staff = new List<Human>(staffList);
        }
    }
}
