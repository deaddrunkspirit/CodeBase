using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T2
{
    class Program
    {
        static void Main()
        {
            Yummy();
        }

        private static void Yummy()
        {
            try
            {
                DirectoryOverview(@"../../../");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Input/output error: ", ex.Message);
            }
            catch (System.Security.SecurityException ex)
            {
                Console.WriteLine("System security error: ", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Uxexpected error: ", ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any koey to exit...");
                Console.ReadLine();
            }
        }

        static void DirectoryOverview(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            for (int i = 0; i < directories.Length; i++)
            {
                string directory = directories[i];
                var directoryInfo = new DirectoryInfo(directory);

                Console.WriteLine($"{ directory}\n" +
                    $"attributes: {directoryInfo.Attributes}" +
                    $"creation time:{directoryInfo.CreationTime}\n" +
                    $"last update:{directoryInfo.LastWriteTime}\n");

                DirectoryOverview(directory);
            }
        }
    }
}
