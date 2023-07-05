using System;

namespace Task3
{
    public class T3
    {
        public delegate double delegateConvertTemperature(double par);

        /// <summary>
        /// Main plot of the program
        /// </summary>
        public static void Main()
        {
            do 
            {
                var tempChanger = new TemperatureConverterImp();
                var temp = new StaticTempConverts();
                delegateConvertTemperature celToFar = tempChanger.CelToFarenheight;
                delegateConvertTemperature farToCel = tempChanger.FarenheightToCel;
                
                // Массив делегатов состоящий из методов 
                // для перевода температуры в различные системы счисления
                delegateConvertTemperature[] converter = 
                    { tempChanger.CelToFarenheight, tempChanger.FarenheightToCel, 
                StaticTempConverts.CelToKelvin, StaticTempConverts.KelvinToCel,
                StaticTempConverts.CelToRankin, StaticTempConverts.RankinToCel,
                StaticTempConverts.CelToReomur, StaticTempConverts.ReomurToCel };

                // First part of the task
                //int cel = GetInt("Task3\nFirst part (convert from celsium to " +
                //    "fareheight and backwards)\n-----\n1 Celcium: ");
                //Console.WriteLine($"2 Farenheight: {celToFar(cel):f3}\n\n");
                //int far = GetInt("3 Farenheight: ");
                //Console.WriteLine($"4 Celcium: {farToCel(far):f3}");

                PrintTable(converter, GetInt("Input degrees in Celcium: "));

                Console.WriteLine($"\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Method which converts temperature
        /// </summary>
        /// <param name="delArr">array of delegates</param>
        /// <param name="celTemp">Celsium temperature</param>
        private static void PrintTable(delegateConvertTemperature[] delArr, double celTemp)
        {
            Console.WriteLine
                ("-----------------------------------------------------\n" +
                "| Celsium | Kelvin | Farenheight | Rankin  | Reomur |\n" +
                "----------------------------------------------------\n" +
                $"| {celTemp:f3}  | {delArr[0](celTemp):f3} | " +
                $"{delArr[2](celTemp):f3}\t | {delArr[4](celTemp):f3} " +
                $"| {delArr[6](celTemp):f3} |\n" +
                $"-----------------------------------------------------\n\n");
        }

        /// <summary>
        /// This method gets integer number from user
        /// </summary>
        /// <param name="mes">message for user</param>
        /// <param name="lower">lower bound of number value</param>
        /// <param name="upper">upper bound of number value</param>
        /// <returns></returns>
        private static int GetInt(string mes = "Input n",
            int lower = 0, int upper = int.MaxValue)
        {
            int n;
            Console.Write(mes);
            while (!int.TryParse(Console.ReadLine(), out n) || n < lower || n > upper)
                Console.WriteLine
                    ($"Please input integer number in [{lower}, {upper}]");
            return n;
        }
    }
}
