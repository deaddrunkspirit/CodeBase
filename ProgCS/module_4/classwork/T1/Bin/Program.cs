using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Task1Lib;

namespace Task1Bin
{
    public class Program
    {
        public static void Main()
        {
            Student[] list172 = {
                new Student("Ivanov", 1), new Student("Petrov", 2),
                new Student("Sidorov", 3)
            };
            var group172 = new Group("SE172", list172);
            Student[] list196 = {
                new Student("Mosolkov", 1), new Student("Dilavar", 2),
                new Student("Vislovich", 3)
            };
            var group196 = new Group("SE196", list196);
            Group[] groups = { group172, group196 };

            var bas = new FileStream("group.ser", FileMode.Create);
            var format = new BinaryFormatter();
            format.Serialize(bas, groups);
            bas.Close();
            bas = new FileStream("group.ser", FileMode.Open);

            Group[] group = (Group[])format.Deserialize(bas);
            Array.ForEach(group, x => Console.WriteLine(x));
            bas.Close();
            Console.ReadKey();
        }
    }
}
