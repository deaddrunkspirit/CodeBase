using ClassLibrary1;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Variant1
{
    public class Program
    {
        private static Random rnd = new Random();

        public static void Main()
        {
            do
            {
                Console.Clear();

                Student student = new Student(GetString(2, 12), GetString(2, 12));
                XmlSerializer formatter = new XmlSerializer(typeof(Student), 
                    new Type[] { typeof(ControlElement[]), typeof(Contest), typeof(ControlWork) });

                SerializeObject(student, formatter);
                DeserializeObject(formatter);

                Console.WriteLine("\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void SerializeObject(Student student, XmlSerializer formatter)
        {
            using (FileStream fs = new FileStream("student1.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, student);

                Console.WriteLine("Object serialized");
            }
        }

        private static void DeserializeObject(XmlSerializer formatter)
        {
            using (FileStream fs = new FileStream("student1.xml", FileMode.OpenOrCreate))
            {
                Student newStudent = (Student)formatter.Deserialize(fs);

                Console.WriteLine("Object deserialized");
                Console.WriteLine(newStudent);
            }
        }

        private static string GetString(int minLength, int maxLength)
        {
            string str = "" + (char)rnd.Next('А', 'Я' + 1);
            int length = rnd.Next(minLength, maxLength + 1);
            for (int i = 0; i < length - 1; i++)
                str += (char)rnd.Next('а', 'я' + 1);

            return str;
        }
    }
}
