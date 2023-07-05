using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Task2Lib;

namespace Task2Binary
{
    public class Program
    {
        public static void Main()
        {
            var HSE = new University() { UniversityName = "NRU HSE" };
            Human[] deptStaff = { new Professor("Ivanov"), new Professor("Petrov") };
            var SE = new Dept("SE", deptStaff);
            HSE.Departments = new List<Dept>();
            HSE.Departments.Add(SE);

            var binformatter = new BinaryFormatter();
            using (Stream file = new FileStream("BinSer.dat", FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                binformatter.Serialize(file, HSE);
            }

            University HSEdeserialized;
            using (Stream file = File.OpenRead("BinSer.dat"))
            {
                HSEdeserialized = (University)binformatter.Deserialize(file);
                Console.WriteLine($"Binary - {HSEdeserialized.UniversityName}");
            }

            foreach (var dept in HSEdeserialized.Departments)
                foreach (var human in dept.Staff)
                    if (human is Professor)
                        Console.WriteLine($"{dept.DeptName} prof.: {human.Name}");
            Console.ReadKey();
        }
    }
}
