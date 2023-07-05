namespace MyClassLibrary
{
    public delegate void countDelegate(int p);

    public class Counter
    {
        private int _n;

        public Counter(int n)
        {
            _n = n;
        }

        public event countDelegate countEvent;

        public void Count()
        {
            for (int i = 0; i < _n; i++)
                countEvent?.Invoke(i);
        }
    }
}