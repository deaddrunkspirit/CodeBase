using System;
using System.Collections.Generic;

namespace Task2Lib
{
    [Serializable]
    public class University
    {
        public string UniversityName { get; set; }
        public List<Dept> Departments { get; set; }
    }
}
