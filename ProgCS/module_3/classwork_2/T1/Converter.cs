namespace Task1Lib
{
    public delegate string ConvertRule(string str);

    public class Converter
    {
        public string Convert(string str, ConvertRule cr) 
            => cr?.Invoke(str);
    }
}
