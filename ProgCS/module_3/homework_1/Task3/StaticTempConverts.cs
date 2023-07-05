namespace Task3
{
    public class StaticTempConverts
    {
        public static double CelToKelvin(double num) => num + 273.15;

        public static double CelToRankin(double num) => (num + 273.15) * 1.8;

        public static double CelToReomur(double num) => 0.8 * num;

        public static double KelvinToCel(double num) => num - 273.15;

        public static double RankinToCel(double num) => (5 / 9) * num - 273.15;

        public static double ReomurToCel(double num) => 1.25 * num;

    } 
}
