namespace Task3
{
    public class TemperatureConverterImp
    {
        public double CelToFarenheight(double cel)
            => 1.8 * cel + 32;

        public double FarenheightToCel(double f)
            => 5 * f / 9 - 32 * 5 / 9;
    }
}
 