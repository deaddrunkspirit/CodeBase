using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Task1Lib;

namespace Task1XMLArray
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

            FileStream bas = new FileStream("group.ser", FileMode.Create);
            XmlSerializer format = new XmlSerializer(typeof(Group[]));
            format.Serialize(bas, groups);
            bas.Close();
            Console.WriteLine("Check group.ser file");
            bas = new FileStream("group.ser", FileMode.Open);

            Group[] gr = (Group[])format.Deserialize(bas);
            Array.ForEach(gr, x => Console.WriteLine(x));

            Console.ReadKey();
        }

    }
}
