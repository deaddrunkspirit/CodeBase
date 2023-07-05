using System;
using System.IO;
using System.Xml.Serialization;

namespace SR
{
    public partial class Program
    {
        private static Random rnd = new Random();

        public static void Main()
        {
            do
            {
                Console.Clear();

                Student student = new Student("Eugen", "Mosolkov");

                XmlSerializer formatter = new XmlSerializer(typeof(Student));

                using (FileStream fs = new FileStream("student.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, student);

                    Console.WriteLine("Объект сериализован");
                }

                using (FileStream fs = new FileStream("student.xml", FileMode.OpenOrCreate))
                {
                    Student newStudent = (Student)formatter.Deserialize(fs);

                    Console.WriteLine("Объект десериализован");
                    Console.WriteLine(newStudent);
                }

                Console.WriteLine("\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
