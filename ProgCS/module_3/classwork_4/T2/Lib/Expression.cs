using System;

namespace Task2Lib
{
    public delegate double ExpDel(double x);

    public delegate void ExpChanged();

    public class Expression
    {
        private ExpDel ex;

        public event ExpChanged OnExpChanged;

        public Expression(ExpDel ex)
        {
            this.ex = ex;
        }

        /// <summary>
        /// Expression value in x
        /// </summary>
        public double ExVal(double x)
            => ex(x);

        public ExpDel Ex { set { ex = value; OnExpChanged(); } }
    }
}