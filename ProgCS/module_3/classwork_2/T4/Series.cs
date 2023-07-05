using System;

namespace Task4
{
    public class Series
    {
        /// <summary>
        /// Private field array of integers
        /// </summary>
        private int[] _arr;

        /// <summary>
        /// Constructor with 1 parametr creates an instance of Series type
        /// </summary>
        /// <param name="arr">array of integers</param>
        public Series(int[] arr)
        {
            _arr = arr;
        }

        /// <summary>
        /// This method sorts array in special way using predicate
        /// </summary>
        /// <param name="predicate">rule of sorting</param>
        public void Order(Comparison<int> predicate) 
        { 
            Array.Sort(_arr, predicate); 
        }
    }
}
