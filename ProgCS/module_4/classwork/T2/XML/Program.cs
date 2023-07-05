using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Task2Lib;

namespace Task2XML
{
    public class Program
    {
        public static void Main()
        {
            University HSE = new University();
            HSE.UniversityName = "NRU HSE";

            Human[] deptStaff = { new Professor("Ivanov"), new Professor("Petrov") };

            Dept SE = new Dept("SE", deptStaff);
            HSE.Departments = new List<Dept>();
            HSE.Departments.Add(SE);

            University MSU = new University();
            MSU.UniversityName = "MSU";

            Human[] deptStaffM = {
                new Professor("Ivanov"),  new Professor("Chizov"),
                new Professor("Petrov")
            };

            Dept SEM = new Dept("SEM", deptStaffM);
            MSU.Departments = new List<Dept>();
            MSU.Departments.Add(SEM);

            University[] universities = new University[] { HSE, MSU };

            XmlSerializer binformatter = new XmlSerializer(typeof(University[]),
                new Type[] { typeof(Dept), typeof(Professor), typeof(Human) });

            using (Stream file = new FileStream("BinSer.dat", FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                binformatter.Serialize(file, universities);
            }

            University[] deserial;
            using (Stream file = File.OpenRead("BinSer.dat"))
            {
                deserial = (University[])binformatter.Deserialize(file);
                Console.WriteLine($"XML - {deserial[0].UniversityName}" +
                    $"\nXML - {deserial[1].UniversityName}");
            }

            foreach (var dept in deserial[0].Departments)
                foreach (var human in dept.Staff)
                    if (human is Professor)
                        Console.WriteLine(dept.DeptName + " prof.: " + human.Name);
            
            foreach (var dept in deserial[1].Departments)
                foreach (var human in dept.Staff)
                    if (human is Professor)
                        Console.WriteLine(dept.DeptName + " prof.: " + human.Name);

            Console.ReadKey();
        }
    }
}
