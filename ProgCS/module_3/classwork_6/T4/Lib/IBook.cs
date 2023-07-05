namespace Task4Lib
{
    public interface IBook : IPublication
    {
        string Author { get; set; }
        int Pages { get; set; }
        string Publisher { get; set; }
        int Year { get; set; }
    }
}