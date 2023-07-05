using System;
using System.Collections.Generic;
using System.Text;

namespace Task2Lib
{
    public class ValueStore
    {
        /// <summary>
        /// expression
        /// </summary>
        private Expression _exp;

        /// <summary>
        /// abscissa point
        /// </summary>
        private double _x0;

        /// <summary>
        /// Current value of expression
        /// </summary>
        private double expCurrValue;

        /// <summary>
        /// Constructor creates an instance of ValueStore
        /// with some expression and abscissa point
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="x0"></param>
        public ValueStore(Expression exp, double x0)
        {
            _exp = exp;
            _x0 = x0;
            expCurrValue = exp.ExVal(x0);
        }

        /// <summary>
        /// Returns current value of expression
        /// </summary>
        public double CurrVal
            => expCurrValue;

        public void OnExpChangeHandler()
        {
            expCurrValue = _exp.ExVal(_x0);
        }
    }
}