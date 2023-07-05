using System;
using Task6Lib;

namespace Task6
{
    public class T6
    {
        /// <summary>
        /// Randomizer
        /// </summary>
        private static Random rnd = new Random();

        /// <summary>
        /// Main plot of the program
        /// </summary>
        public static void Main()
        {
            do
            {
                int arrSize = GetInt();
                Plant[] plantArr = new Plant[arrSize];
                FillPlantArray(plantArr);
                PrintArr(plantArr);
                Array.Sort(plantArr, delegate (Plant plant1, Plant plant2)
                {
                    if (plant1.Growth > plant2.Growth) return -1;
                    if (plant1.Growth == plant2.Growth) return 0;
                    return 1;
                });
                PrintArr(plantArr, "Growth decreasing:");
                Array.Sort(plantArr, (Plant plant1, Plant plant2) =>
                {
                    if (plant1.FrostResist > plant2.FrostResist) return 1;
                    if (plant1.FrostResist == plant2.FrostResist) return 0;
                    return -1;
                });
                PrintArr(plantArr, "Frostresistance increasing:");
                Array.Sort(plantArr, PhotoSensSort);
                PrintArr(plantArr, "Photosensivity even:");
                plantArr = Array.ConvertAll(plantArr, plant => plant.FrostResist % 2 == 0 ?
                new Plant(plant.Growth, plant.PhotoSens, plant.FrostResist / 3) :
                new Plant(plant.Growth, plant.PhotoSens, plant.FrostResist / 2));
                Console.WriteLine("\n\nTo exit press Escape key\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static int PhotoSensSort(Plant plant1, Plant plant2) 
            => (plant1.PhotoSens % 2).CompareTo(plant2.PhotoSens % 2);

        /// <summary>
        /// This method fills array of Plants
        /// </summary>
        /// <param name="plantArr">array of plants</param>
        private static void FillPlantArray(Plant[] plantArr)
        {
            for (int i = 0; i < plantArr.Length; i++)
                plantArr[i] = new Plant(GenerateDouble(25, 100),
                    GenerateDouble(0, 100), GenerateDouble(0, 80));
        }

        /// <summary>
        /// This method prints an array of double numbers
        /// </summary>
        /// <param name="arr">array of double numbers</param>
        /// <param name="mes">message</param>
        private static void PrintArr(Plant[] arr, string mes = "Array:\t") 
        {
            Console.WriteLine($"{mes}\n---------------");
            Array.ForEach(arr, el => Console.WriteLine($"{el}"));
            Console.WriteLine("---------------");
        }

        /// <summary>
        /// This method generates a double value
        /// </summary>
        /// <param name="lower">lower bound of number value</param>
        /// <param name="upper">upper bound of number value</param>
        /// <returns></returns>
        private static double GenerateDouble(int lower, int upper)
            => rnd.NextDouble() + rnd.Next(lower, upper);

        /// <summary>
        /// This method gets an integer from user
        /// </summary>
        /// <param name="mes">message for user</param>
        /// <param name="lower">lower bound of number value</param>
        /// <param name="upper">upper bound of number value</param>
        /// <returns></returns>
        private static int GetInt(string mes = "Input the size of plant array: ",
            int lower = 1, int upper = int.MaxValue)
        {
            Console.Write(mes);
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) 
                || number < lower || number > upper)
                Console.WriteLine($"Please input integer in [{lower}, {upper}]");
            return number;
        }
    }
}
