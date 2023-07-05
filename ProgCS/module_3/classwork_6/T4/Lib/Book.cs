namespace Task4Lib
{
    public class Book : IBook
    {
        public string Author { get; set; }

        public int Pages { get; set; }

        public string Publisher { get; set; }

        public int Year { get; set; }

        public string Title { get; set; }

        public void Read()
        {
        }

        public void Write()
        {
        }
    }
}