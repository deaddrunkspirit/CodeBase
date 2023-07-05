using System;

namespace Task7Lib
{
    public delegate void SortHandler(long cn, int si, int kl);

    public class Sorting
    {
        int[] arr;
        
        public long count;
        
        public event SortHandler onSort;
        
        public Sorting(int[] arr)
        {
            count = 0;
            this.arr = arr;
        }

        public void Sort()
        {
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                onSort?.Invoke(count, arr.Length, i);
            }
        }

    }
}
