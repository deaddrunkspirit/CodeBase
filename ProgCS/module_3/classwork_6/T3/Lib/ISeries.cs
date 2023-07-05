namespace Task3Lib
{
    public interface ISeries
    {
        void SetBegin();

        int GetNext { get; }
        int this[int k] { get; }
    }
}