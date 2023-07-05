using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Task1Lib;

namespace Task1
{
    public class Program
    {
        public static void Main()
        {
            Student[] list196 = {
                new Student("Mosolkov", 1), new Student("Dilavar", 2),
                new Student("Vislovich", 3)
            };
            var group196 = new Group("SE196", list196);

            var bas = new FileStream("group.ser", FileMode.Create);
            var format = new BinaryFormatter();
            format.Serialize(bas, group196);
            bas.Close();
            bas = new FileStream("group.ser", FileMode.Open);
            Group group = (Group)format.Deserialize(bas);
            Console.WriteLine(group.ToString());
            bas.Close();
            Console.ReadKey();
        }
    }
}
