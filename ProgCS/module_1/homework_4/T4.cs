using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T4
{
    /*class Program
    {
        static void Main()
        {
            // Create a string with a line of text.
            string text = "First line" + Environment.NewLine;

            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the text to a new file named "WriteFile.txt".
            File.WriteAllText(Path.Combine(docPath, "xuxuxu.txt"), text);

            // Create a string array with the additional lines of text
            string[] lines = { "New line 1", "New line 2" };

            // Append new lines of text to the file
            File.AppendAllLines(Path.Combine(docPath, "xuxuxu.txt"), lines);
        }
    }*/
    class Test
    {
        public static void Main()
        {
            string path = @"/MyTest.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
