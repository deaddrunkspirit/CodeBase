using PetLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Test
{
    public class Program
    {
        /// <summary>
        /// Randomizer
        /// </summary>
        private static Random rnd = new Random();

        /// <summary>
        /// Count of attempts to create a pet and add it to pet list
        /// </summary>
        private const int petsCount = 40;

        /// <summary>
        /// Main plot of the programm
        /// </summary>
        public static void Main()
        {
            do
            {
                Console.Clear();
                Console.OutputEncoding = Encoding.UTF8;
                string petsByIComparable = "2PetsByIComparable.txt",
                    petsByName = "3PetsByName.txt",
                    petsByTypeAndMass = "4PetsByTypeAndMass.txt";

                var pets = new List<IPet>();
                GeneratePetList(pets);

                pets.Sort();
                WriteList(petsByIComparable, pets);

                pets.Sort((firstPet, secondPet) => 
                    string.Compare(firstPet.Name, secondPet.Name, StringComparison.Ordinal));
                WriteList(petsByName, pets);

                pets.Sort(delegate (IPet firstPet, IPet secondPet)
                {
                    if (firstPet is Cat)
                        return secondPet is Cat ? firstPet.CompareTo(secondPet) : -1;

                    return secondPet is Cat ? 1 : firstPet.CompareTo(secondPet);
                });
                WriteList(petsByTypeAndMass, pets);

                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// This method outputs a list of pets to special file
        /// </summary>
        /// <param name="path">file path</param>
        /// <param name="pets">list of Pet</param>
        private static void WriteList(string path, List<IPet> pets)
        {
            try
            {
                using (var sw = new StreamWriter(path, false, Encoding.GetEncoding("UTF-16")))
                    foreach (var pet in pets)
                        sw.WriteLine(pet);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при работе с файлом:\n\t{path}\n{e.Message}");
            }
        }

        /// <summary>
        /// This method generates Pet instances and adds them to the list of pets
        /// </summary>
        /// <param name="pets">list of pets</param>
        private static void GeneratePetList(List<IPet> pets)
        {
            for (int i = 0; i < petsCount; i++)
            {
                int coin = rnd.Next(1, 3);
                try
                {
                    switch (coin)
                    {
                        case 1:
                            pets.Add(new Cat(GetName(), GetMass()));
                            break;
                        case 2:
                            pets.Add(new Dog(GetName(), GetMass()));
                            break;
                    }
                }
                catch (PetException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        /// <summary>
        /// This method gets pet's name 
        /// </summary>
        /// <returns></returns>
        private static string GetName()
        {
            int length = rnd.Next(2, 14);
            string name = $"{(char)rnd.Next('A', 'Z' + 1)}";
            for (int i = 0; i < length - 1; i++)
                name += (char)rnd.Next('a', 'z' + 1);

            return name;
        }

        /// <summary>
        /// This method gets pet's mass
        /// </summary>
        /// <returns></returns>
        private static double GetMass() => rnd.Next(-5, 15) + rnd.NextDouble();
    }
}
