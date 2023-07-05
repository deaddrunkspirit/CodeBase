using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Task1Lib;

namespace Task1XML
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

            FileStream bas = new FileStream("group.ser", FileMode.Create);
            XmlSerializer format = new XmlSerializer(typeof(Group), new Type[] { typeof(Student) });
            format.Serialize(bas, group196);
            bas.Close();
            Console.WriteLine("Check group.ser file");
            bas = new FileStream("group.ser", FileMode.Open);

            Group gr = (Group)format.Deserialize(bas);
            Console.WriteLine(gr.ToString());

            Console.ReadKey();
        }
    }
}
