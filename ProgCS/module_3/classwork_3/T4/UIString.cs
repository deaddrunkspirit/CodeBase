using System;

namespace Task4Lib
{
    public class UIString
    {
        private string str = "Default text";

        public string Str { get { return str; } set { str = value; } }

        public void NewStringHappenedHandler(string s)
        {
            str = s;
        }
    }
}
