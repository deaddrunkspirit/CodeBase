namespace Task1Lib
{
    public class ColorPoint
    {
        public static string[] colors = {
            "Red", "Green", "DarkRed", "Magenta",
            "DarkSeaGreen", "Lime", "Purple", "DarkGreen",
            "DarkOrange", "Black", "BlueViolet", "Crimson",
            "Gray", "Brown", "CadetBlue",
        };

        public double x, y;
        public string color;
        public override string ToString()
            => $"{x:f3}\t{y:f3}\t{color}";
    }
}
