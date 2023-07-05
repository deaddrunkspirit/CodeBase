namespace Task4Lib
{
    public interface IPublication
    {
        void Write();

        void Read();

        string Title { get; set; }
    }
}